using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace GraphDiplom
{
    // класс транспортной сети содержащий структуру и основные алгоритмы в графе
    public class TransportWeb
    {
        // массив-список узлов
        public List<GraphNode> allNodes = new List<GraphNode>();
        // массив-список путей
        public List<GraphPath> allPaths = new List<GraphPath>();
        // этот массив-список хранит номер итерации и значение f при ней
        public List<Vec2> allFlowValues = new List<Vec2>();
        // этот массив-список хранит номер итерации и строку с историей перемещения потока между узлами
        public List<Vec2> strFlowHistory = new List<Vec2>();

        // эта переменная нужна только для 4 задания, для хранения истории перемещений
        // минимального потока
       public string minFlowHistory = "";

        // эта переменная сохраняет все расчёты алгоритма
        // которые доступны по нажатию по кнопке "расчёты"
        public string descFordFalk = "";

        //public TransportWeb() {}

        // очищает сеть и удаляет все узлы и рёбра
        public void clearWeb()
        {
            allNodes.Clear();
            allPaths.Clear();
        }

        // АЛГОРИТМ ФОРДА-ФАЛКЕРСОНА
        // дополнительные логические переменные-аргументы withIntervals и т.д.
        // ищут решение с дополнительными условиями (например если withIntervals = true)
        // то сеть анализируется с учётом интервалов рёбер
        public int calculateFordFalk(bool withIntervals = false, bool withAbsorption = false, bool onlyMinFlow = false)
        {
            descFordFalk = "";

            // проверяем что бы у всех рёбер была указана пропускная способность
            foreach (GraphPath p in allPaths)
            {
                // если пропускная способность не указана, показываем предупреждение
                if (p.ffLabel.x.GetType() != typeof(int) && p.ffLabel.x == FastMath.SYMBOLS.UNKNOWN)
                    return -1;
            }

            // когда одна их этих переменных станет true расчёт решения завершится
            bool calculated = false;
            bool calculatedWithIntervals = true; // если false то расчитывается вместе с интервалами

            // доп.переменные для задания 2
            bool isShuffleApply = false; // станет true когда сеть после первой проверки прибавит новые значения

            
            // эта переменная хранит результат 1,2,3 заданий
            int result = 0;

            // счётчик итераций цикла
            int iNumber = 0;

            // сохраняем начальные значения пропускных способностей в рёбрах
            foreach (GraphPath p in allPaths)
                p.ffLabelInit = new Vec2(p.ffLabel.x, p.ffLabel.y);

            // ВНИМАНИЕ! В переменную descFordFalc поэтапно записываются все важные расчёты алгоритма
            // после результата все данные из неё записываются в textbox
            // в главной форме (доступен по клике на кнопку "расчёты"
            // + '\r' + '\n' : это просто перенос строки
            descFordFalk += "НАЧАЛО РАБОТЫ АЛГОРИТМА ФОРДА-ФАЛКЕРСОНА... " + '\r' + "\n";

            // (ЗАДАНИЕ 2) если нужно рассчитать учитывая интервалы, приводим сеть к классическому виду
            if (withIntervals)
            {
                calculatedWithIntervals = false;

                descFordFalk += "ПРИСУТСТВУЮТ ИНТЕРВАЛЫ, приводим сеть к классическому виду... " + '\r' + "\n";

                foreach (GraphPath p in allPaths)
                {
                    int prevFFLabelX = p.ffLabel.x;
                    int prevFFLabelY = p.ffLabel.y;

                    descFordFalk += p.generateName() + " -> " + 
                        Convert.ToString(prevFFLabelY) + " - " + Convert.ToString(prevFFLabelX);

                    p.ffLabel.x = prevFFLabelY - prevFFLabelX;
                    p.ffLabel.y = 0;

                    if (p.ffLabel.x < 0)
                        p.ffLabel.x = 0;

                    descFordFalk +=  " = " + Convert.ToString(p.ffLabel.x) + '\r' + "\n";
                    
                }

                descFordFalk += "СЕТЬ ПРИВЕДЕНА К КЛАССИЧЕСКОМУ ВИДУ " + '\r' + "\n";

            }

            // (ЗАДАНИЕ 3) если нужно рассчитать м.п.с. учитывая поглощение узлов
            // создаём дополнительный сток, соединяем его с поглощяющими узлами
            // и задаём приоритет потоку в рёбрах между ними
            else if (withAbsorption)
            {
                // создаём промежуточный сток в координатах 10,10
                GraphNode additFinish = addNode(new GraphNode(new Vec2(430, 50)), true);
                additFinish.isFinishAddit = true;
                additFinish.hasPriority = true; // выставляем повышенный приоритет

                // находим все узлы имеющие не нулевое поглощение
                List<GraphNode> absoNodes = new List<GraphNode>();
                foreach (GraphNode aNode in allNodes)
                    if (aNode.absorption > 0)
                        absoNodes.Add(aNode);

                // сумма всех пропускных способностей путей между 
                // узлами с поглощением и промежуточным стоком
                int ffSum = 0;

                // если таких узлов больше нуля
                if (absoNodes.Count() > 0)
                {
                    // соединяем каждый из них с промежуточным стоком, и выставляем
                    // пропускную способность ребёр равную значению поглощения
                    foreach (GraphNode absoNode in absoNodes)
                    {
                        absoNode.hasPriority = true; // выставляем узлу повышенный приоритет
                        GraphPath newP = addPath(absoNode, additFinish);
                        newP.setFFLabel(absoNode.absorption, 0);
                        ffSum += newP.ffLabel.x;
                    }
                }

                // наконец соединяем промежуточный сток с настоящим
                GraphPath finishNodesPath = addPath(additFinish, findFinishNode());
                finishNodesPath.setFFLabel(ffSum, 0);
                
            }

            while (!calculated || !calculatedWithIntervals) 
            {
                // очищаем метки с узлов
                foreach (GraphNode n in allNodes)
                    if (!n.isStart)
                        n.ffLabel = new Vec2(0, 0);

                GraphNode curNode = findStartNode(); // начинаем с 1
                GraphPath curPath = allPaths[0];

                GraphNode finishNode = findFinishNode();

                // если нет стока показываем предупреждение
                if (finishNode == null)
                    return -1;

                // СОЗДАЁМ СПИСКИ-МАССИВЫ СКВОЗНЫХ ПУТЕЙ
                List<GraphNode> sNodes = new List<GraphNode>();
                List<GraphPath> sPaths = new List<GraphPath>();

                iNumber += 1;
                

                int maxNodeNum = 1;

                // счётчик для вывода ошибки и остановки цикла while
                int errorCounter = 0;

                while (curNode.num != finishNode.num)
                {
                    // если цикл обрабатывается слишком долго
                    // останавливаем его и выводим ошибку
                    errorCounter += 1;
                    if (errorCounter == 100)
                    {
                        descFordFalk += "ОШИБКА! АНАЛИЗ ОСТАНОВЛЕН.";
                        return 1000;
                    }

                    List<GraphNode> connectedNodes = findConnectedNodes(curNode);
                    List<GraphNode> S = new List<GraphNode>();

                    // добавляем во множество S только пути с положительной пропуск. способн.
                    // и без меток
                    descFordFalk += "S = { ";
                    foreach (GraphNode n in connectedNodes)
                    {
                        GraphPath commonPath = findCommonPathForNodes(curNode, n);
                        // получаем пропускную способность в зависимости от направления ребра
                        int correctFlowValue = commonPath.getCorrectFlowValueByDir(curNode, n);

                        if (curNode.hasPriority && n.isFinishAddit)
                        {
                            //correctFlowValue = commonPath.ffLabel.x;
                            descFordFalk += " " + Convert.ToString(commonPath.ffLabel.x)  + '\r' + "\n";
                        }

                        //descFordFalk += "fdsfsadf "+ Convert.ToString(findCommonPathForNodes(n, findFinishNode()).ffLabel.x) + '\r' + "\n";

                        if (!n.isStart && n.ffLabel.x == 0 && n.ffLabel.y == 0 && correctFlowValue > 0)
                        {
                            
                            // добавляем во множество S
                            S.Add(n);
                            descFordFalk += Convert.ToString(n.num) + " ";
                            
                        }
                    }
                    descFordFalk += "}" + '\r' + "\n";

                    // распределяем узлы по приоритету в образованном множестве
                    // если найден путь в дополнительный сток, оставляем в S только его
                    // если такого нет но присутствуют узлы с приоритетом
                    // оставляем в S только их

                    List<GraphNode> priorNodes = new List<GraphNode>();
                    if (withAbsorption)
                    {
                        descFordFalk += "ИЩЕМ УЗЛЫ С ПРИОРИТЕТОМ" + '\r' + "\n";
                        
                        // если сейчас анализируется дополнительный сток
                        // и существует путь от него к настоящему стоку
                        // оставляем только этот путь
                        foreach (GraphNode sNode in S)
                        {
                            if (sNode.isFinishAddit)
                            {
                                priorNodes.Clear();
                                priorNodes.Add(sNode);

                                descFordFalk += "Узел: " + Convert.ToString(sNode.num) + " ДОПОЛНИТЕЛЬНЫЙ СТОК" +
                                    '\r' + "\n";
                                
                                break;
                            }
                            else if (sNode.hasPriority)
                            {
                                descFordFalk += "Узел: " + Convert.ToString(sNode.num) + " имеет приоритет" +
                                    '\r' + "\n";
                                priorNodes.Add(sNode);
                            }
                        }

                        // если присутствуют узлы с повышенным приоритетом
                        // оставляем в множестве S только их
                        if (priorNodes.Count() > 0)
                        {
                            descFordFalk += "Количество п. узлов: " + Convert.ToString(priorNodes.Count()) +
                                    '\r' + "\n";
                            S.Clear();
                            foreach (GraphNode pn in priorNodes)
                            {
                                S.Add(pn);
                                break;
                            }
                        }
                        else
                        {
                            descFordFalk += "УЗЛЫ НЕ НАЙДЕНЫ" + '\r' + "\n";
                        }
                    }
                    else if (curNode.isFinishAddit)
                    {
                        descFordFalk += "АНАЛИЗИРУЕМ ДОПОЛНИТЕЛЬНЫЙ СТОК" +
                                    '\r' + "\n";
                        foreach (GraphNode sNode in sNodes)
                            if (sNode.isFinish)
                            {
                                sNodes.Clear();
                                sNodes.Add(findFinishNode());
                            }
                    }

                    int flowValue = 0;
                    int maxFlowCount = 0;

                    if (S.Count() > 0)
                    {
                        descFordFalk += "S - не пустое, продолжаем" + '\r' + "\n";
                        // ищем максимальную пропускную спобность в множестве S
                        foreach (GraphNode sNode in S)
                        {
                            if (sNode.ffLabel.x == 0 )
                            {
                                GraphPath commonPath = findCommonPathForNodes(curNode, sNode);
                                flowValue = commonPath.getCorrectFlowValueByDir(curNode, sNode);


                                if (flowValue > maxFlowCount)
                                {
                                    maxFlowCount = flowValue;
                                    maxNodeNum = sNode.num;
                                    curPath = commonPath;
                                }
                                
                            }
                        }

                        descFordFalk += "S(max) : " +
                            Convert.ToString(maxNodeNum) + " [" + Convert.ToString(maxFlowCount) + "]" + '\r' + "\n";

                        GraphNode newCurNode = findNodeByNum(maxNodeNum);
                        newCurNode.ffLabel = new Vec2(maxFlowCount, curNode.num);

                        sNodes.Add(newCurNode);
                        sPaths.Add(curPath);

                        curNode = newCurNode;

                        if (curNode.isFinish)
                            break;
                    }
                    else // если нет путей из этого узла
                    {
                        descFordFalk +=
                            "Узел (" + Convert.ToString(curNode.num) + ")" +
                            " Доступных путей нет!" + '\r' + "\n";

                        // если нет путей из истока, подсчитываем результат
                        if (curNode.isStart || sNodes.Count() == 1)
                        {
                            
                            // если нужно выполнить повторную проверку (в задаче 2)
                            // с новыми значениями пропускных потоков
                            if (!calculatedWithIntervals && !isShuffleApply) // ТОЛЬКО ЗАДАНИЕ 2
                            {
                                // выставляем новую пр. способ. исходя из старых и новый значений потоков
                                foreach (GraphPath p in allPaths)
                                {

                                    descFordFalk += p.name + " [проп.способ.] : " +
                                        Convert.ToString(p.ffLabelInit.x) + " + " +
                                        Convert.ToString(p.getSuccessFlowsSum()) + " = ";

                                    p.ffLabel.x = p.ffLabelInit.x + p.getSuccessFlowsSum();
                                    p.ffLabel.y = 0;

                                    descFordFalk += Convert.ToString(p.ffLabel.x) + '\r' + "\n";
                                }

                                descFordFalk += "ЗАНОВО АНАЛИЗИРУЕМ СЕТЬ С НОВЫМИ ЗНАЧЕНИЯМИ.." + '\r' + "\n";

                                foreach (GraphNode n in allNodes)
                                    if (!n.isStart)
                                        n.ffLabel = new Vec2(0, 0);

                                curNode = findStartNode();
                                curPath = allPaths[0];
                                isShuffleApply = true;
                            }
                            else
                            {
                                // если нужно решить задание 4 то результатом будет 
                                // поток с минимальным f
                                if (onlyMinFlow)
                                {
                                    // ищем минимальное значение и сохраняем текстовое описание
                                    // потока на данной операции
                                    int minIterValue = 1;
                                    int minFValue = allFlowValues[0].y;
                                    foreach (Vec2 flowF in allFlowValues)
                                        if (flowF.y < minFValue)
                                        {
                                            minIterValue = flowF.x;
                                            minFValue = flowF.y;
                                        }
                                    // ищем текстовую историю этого потоку по номеру итерации
                                    foreach (Vec2 flowHistory in strFlowHistory)
                                        if (flowHistory.x == minIterValue)
                                            minFlowHistory = flowHistory.y;

                                    return minIterValue;
                                }
                                else // для всех остальных 
                                {
                                    descFordFalk += "ИСТОК ЗАБЛОКИРОВАН. РЕШЕНИЕ НАЙДЕНО." + '\r' + "\n";

                                    calculated = true;
                                    calculatedWithIntervals = true;

                                    break; // РЕШЕНИЕ НАЙДЕНО, ОСТАНАВЛИВАЕМ ЦИКЛ WHILE
                                }
                            }
                        }
                        else
                        {
                            // ЕСЛИ ИЗ УЗЛА НЕТ ДОСТУПНЫХ ПУТЕЙ, ВОЗВРАЩАЕМСЯ К ПРЕДЫДУЩЕМУ
                            descFordFalk += "Из узла " +
                                Convert.ToString(sNodes[sNodes.Count() - 1].num) +
                                " нет путей, блокируем его" + '\r' + "\n";
                            descFordFalk += "Возвращаемся к узлу " +
                                Convert.ToString(sNodes[sNodes.Count() - 2].num) + '\r' + "\n";

                            curNode.ffLabel = new Vec2(FastMath.SYMBOLS.REMOVED, FastMath.SYMBOLS.REMOVED);
                            // удаляем текущий узел из доступных для анализа
                            // и проверяем заново прошлый
                            curNode = sNodes[sNodes.Count() - 2];
                            sNodes.RemoveAt(sNodes.Count() - 1);
                            continue;
                        }
                    }

                } 
              // ИЩЕМ НАИМЕНЬШУЮ ПРОПУСК. СПОСОБНОСТЬ
                // ВЫСТАВЛЯЕМ НОВЫЕ ЗНАЧЕНЬЯ ПР.СП. ДЛЯ РЁБЕР
                if (!calculated)
                {
                    // ищем минимальный f
                    int f = 0;
                    int minNodeNum = -1;
                    foreach (GraphNode n in sNodes)
                        if (!n.isStart)
                            if (f == 0 || n.ffLabel.x < f)
                            {
                                f = n.ffLabel.x;
                                minNodeNum = n.num;
                            }

                    descFordFalk += "S(min) : " + Convert.ToString(minNodeNum) + " [" +
                        Convert.ToString(f) + "]" + '\r' + "\n";

                    descFordFalk += "Расчёт новых меток для рёбер.." + '\r' + "\n";

                    // выставляем новые метки на рёбра по формуле
                    foreach (GraphPath p in sPaths)
                    {
                        descFordFalk += p.name +
                            " => (" + Convert.ToString(p.ffLabel.x) + " - f[" + Convert.ToString(f) + "], " +
                            Convert.ToString(p.ffLabel.y) + " + f[" + Convert.ToString(f) + "])" + '\r' + "\n";

                        p.ffLabel = new Vec2(p.ffLabel.x - f, p.ffLabel.y + f);

                        if (p.ffLabel.x < 0)
                            p.ffLabel.x = 0;
                        if (p.ffLabel.y < 0)
                            p.ffLabel.y = 0;

                        descFordFalk += p.name +
                            " : (" + Convert.ToString(p.ffLabel.x) + ", " +
                            Convert.ToString(p.ffLabel.y) + ")" + '\r' + "\n";

                        p.successFlows.Add(f); // записываем f успешного потока в ребро ( например ребро1(1)(1)(2) )

                        descFordFalk += p.name + " Потоки : ";

                        foreach (int prevF in p.successFlows)
                            descFordFalk += "(" + Convert.ToString(prevF) + ")";

                        descFordFalk += '\r' + "\n";
                    }
                    descFordFalk += "Результат F (" + Convert.ToString(result) +
                        ") += " + Convert.ToString(f) + '\r' + "\n";

                    // вносим значение данное f в массив всех значений f
                    allFlowValues.Add(new Vec2(iNumber,f));

                    // создаём текстовую историю перемещений потока
                    // например 2 3 1 5
                    string flowsHistory = "";
                    foreach (GraphNode sn in sNodes)
                    {
                        flowsHistory += Convert.ToString(sn.num) + " ";
                    }

                    // вносим текст истории перемещений потока в массив
                    strFlowHistory.Add(new Vec2(iNumber, flowsHistory));

                    result += f;
                }
                
            }

            descFordFalk += "АНАЛИЗ ЗАКОНЧЕН. Результат : " + Convert.ToString(result);
            return result;
        }

        /// ОПЕРАЦИИ С УЗЛАМИ ///
        // добавляет узел в список-массив и возвращает его для манипуляций
        public GraphNode addNode(GraphNode n, bool disablePathAutoGen = false)
        {
            // получаем номер узла по количеству эл-ов в списке allNodes
            n.num = allNodes.Count() + 1; 

            // если это первый узел автоматически делаем его истоком
            if (n.num == 1)
            {
                makeNodeStart(n);
                
            }
            // иначе, если есть выбранный узел добавляем путь он тего к новому
            // если ни один узел не выбран, прокладываем путь от последнего добавленного
            else
            {
                GraphNode fromNode = findSelectedNode();
                // если узел не выбран, берем последний
                if (fromNode == null)
                    fromNode = findNodeByNum(allNodes.Count());

                if (!disablePathAutoGen)
                    addPath(fromNode, n);
            }
            
            allNodes.Add(n);

            return n;
        }
        // этот метод находит все узлы соединённые с выбранным узлом
        public List<GraphNode> findConnectedNodes(GraphNode n)
        {
            List<GraphNode> connectedNodes = new List<GraphNode>();

            for (int i = 0; i < allPaths.Count(); i++)
            {
                GraphPath currentPath = allPaths[i];
                if (currentPath.nodeFrom == n)
                {
                    connectedNodes.Add(currentPath.nodeTo);
                }
                else if (currentPath.nodeTo == n)
                {
                    connectedNodes.Add(currentPath.nodeFrom);
                }
            }
            
            return connectedNodes;
        }

        // чтобы была возможность кликом мыши выбирать узел
        // нужно найти координаты ближайшего узла к координатам курсора мыши в момент клика
        // этот метод проверяет координаты всех узлов и если находит один с допустимым расстоянием
        // возвращает подходящий узел
        public GraphNode findNearestNodeToPos(Vec2 pos)
        {
            // допустимая дистанция
            int availableDist = 15;

            for (int i = 0; i < allNodes.Count(); i++)
            {
                // если нашёлся близкий к клику узел, то выбираем его
                if (FastMath.calculateDist(pos, allNodes[i].pos) <= availableDist)  
                    return allNodes[i];
            }
            // если нет ближайших к позиции узлов, возвращаем null
            return null;
        }
        // выбрать узел
        public void selectNode(GraphNode n)
        {
            // делаем не активными все узлы
            for (int i = 0; i < allNodes.Count(); i++)
                allNodes[i].isSelected = false;

            // выбираем (делаем активным) нужный
            n.isSelected = true;
        }
        // соединить узлы
        public void connectNodes(GraphNode n1, GraphNode n2)
        {
            addPath(n1, n2);
        }

        // сделать узел истоком
        public void makeNodeStart(GraphNode n)
        {
            // делаем прошлый исток обычным узлом
            var prevStartNode = findStartNode();

            if (prevStartNode != null)
            {
                prevStartNode.isStart = false;
                // ставим новому истоку номер 1 и прошлому даём прежний номер
                prevStartNode.num = n.num;
                n.num = 1;
            }

            // выбираем (делаем активным) нужный
            n.isStart = true;
            // ставим истоку метку [oo,-] (бесконечность/прочерк)
            n.ffLabel = new Vec2(FastMath.SYMBOLS.INF, FastMath.SYMBOLS.DASH);
        }
        // сделать узел стоком
        public void makeNodeFinish(GraphNode n)
        {
            // делаем не активными все узлы
            for (int i = 0; i < allNodes.Count(); i++)
                allNodes[i].isFinish = false;

            // выбираем (делаем активным) нужный
            n.isFinish = true;
        }

        // найти узел по номеру
        public GraphNode findNodeByNum(int num)
        {
            for (int i = 0; i < allNodes.Count(); i++)
            {
                if (allNodes[i].num == num)
                    return allNodes[i];
            }
            // если узлов с таким номером нет, возвращаем null
            Console.WriteLine("КРИТИЧЕСКАЯ ОШИБКА! УЗЛОВ С ТАКИМ НОМЕРОМ НЕТ!");
            return null;
        }
        // найти выбранный узел
        public GraphNode findSelectedNode()
        {
            for (int i = 0; i < allNodes.Count(); i++)
            {
                if (allNodes[i].isSelected)
                    return allNodes[i];
            }
            // если ни один узел не выбран возвращаем null
            return null;
        }
        // найти исток
        public GraphNode findStartNode()
        {
            for (int i = 0; i < allNodes.Count(); i++)
            {
                if (allNodes[i].isStart)
                    return allNodes[i];
            }
            // если ни один узел не выбран возвращаем null
            return null;
        }
        // найти сток
        public GraphNode findFinishNode()
        {
            for (int i = 0; i < allNodes.Count(); i++)
            {
                if (allNodes[i].isFinish)
                    return allNodes[i];
            }
            // если ни один узел не выбран возвращаем null
            return null;
        }

        /// ОПЕРАЦИИ С РЁБРАМИ ///
        // добавить ребро, от узла fromNode к узлу toNode
        public GraphPath addPath(GraphNode fromNode, GraphNode toNode)
        {
            // настраиваем ребро и добавляем в список
            GraphPath newPath = new GraphPath(fromNode, toNode);
            newPath.startSetup(allPaths.Count());

            fromNode.connectedPaths.Add(newPath);
            toNode.connectedPaths.Add(newPath);

            allPaths.Add(newPath);

            return newPath;
        }

        // выбрать ребро
        public void selectPath(GraphPath p)
        {
            // делаем не активным прошлое выбранное ребро
            GraphPath prevSelectedPath = findSelectedPath();
            if (prevSelectedPath != null)
                prevSelectedPath.isSelected = false;

            // выбираем новое ребро
            p.isSelected = true;
        }
        // найти выбранное ребро
        public GraphPath findSelectedPath()
        {
            for (int i = 0; i < allPaths.Count(); i++)
            {
                if (allPaths[i].isSelected)
                    return allPaths[i];
            }
            return null;
        }
        // найти ребро по имени
        public GraphPath findPathByName(string name)
        {
            for (int i = 0; i < allPaths.Count(); i++)
            {
                if (allPaths[i].name == name)
                    return allPaths[i];
            }
            return null;
        }

        // найти все рёбра связанные с узлом
        public List<GraphPath> findAllPathsInNode(GraphNode n)
        {
            List<GraphPath> nodePaths = new List<GraphPath>();

            // проверяем все рёбра и добавляем те которые связаны с узлом в список-массив
            for (int i = 0; i < allPaths.Count(); i++) 
            {
                if (allPaths[i].nodeFrom == n || allPaths[i].nodeTo == n)
                    nodePaths.Add(allPaths[i]);
            }

            return nodePaths;
        }

        // найти общий путь для двух узлов
        public GraphPath findCommonPathForNodes(GraphNode n1, GraphNode n2)
        {
            for (int i = 0; i < n1.connectedPaths.Count(); i++)
            {
                if (n1.connectedPaths[i].nodeFrom == n2 || n1.connectedPaths[i].nodeTo == n2)
                {
                    return n1.connectedPaths[i];
                }
            }
            return null;
        }
    }

    // класс узлов в графе
    public class GraphNode
    {
        public int num; // номер узла

        public bool isStart = false; // это исток?
        public bool isFinish = false; // это сток?
        public bool isSelected = false; // узел выбран?

        public bool isFinishAddit = false; // это промежуточный сток?

        // здесь переменные для графического отображения
        public Vec2 pos; // позиция узла
        public Vec2 size = new Vec2(40, 40); // размер круга

        // переменные для алгоритма Форда-Фалкерсона
        public Vec2 ffLabel = new Vec2(0,0); // метка узла
        public int correctFlowValue = 0; // сумма f прошедших потоков
            // для задания 3
        public int absorption = 0; // поглощение
        public bool hasPriority = false; // имеет ли узел приоритет

        // список присоединённых рёбер
        public List<GraphPath> connectedPaths = new List<GraphPath>();

        public GraphNode(Vec2 pos) 
        {
            this.pos = pos;
        }

        // получить координаты центра в круге
        public Vec2 getCenterPos()
        {
            if (pos != null && size != null)
                return new Vec2((int)pos.x - size.x / 2, (int)pos.y - size.y / 2);
            else
            {
                Console.WriteLine("ОШИБКА! ПОЗИЦИЯ ИЛИ РАЗМЕР УЗЛА РАВЕН NULL!");
                return new Vec2(0, 0);
            }
        }
    }

    // класс ребра между узлами
    public class GraphPath
    {
        // содержит узлы из которых начинается путь и в котором заканчивается
        public GraphNode nodeFrom, nodeTo;

        public int id;
        public string name;

        public bool isSelected = false;

        // переменные для алгоритма Форда-Фалкерсона
        public Vec2 ffLabel = new Vec2(
            FastMath.SYMBOLS.UNKNOWN, FastMath.SYMBOLS.UNKNOWN); // метка для алгоритма ФФ и пропускная способность
        public Vec2 ffLabelInit = new Vec2(0,0);
        
        // список содержащий номера успешно прошедших потоков
        public List<int> successFlows = new List<int>(); 

        public GraphPath(GraphNode nFrom, GraphNode nTo) 
        {
            this.nodeFrom = nFrom;
            this.nodeTo = nTo;
        }

        // этот метод производит первоначальную  
        // настройку ребра ( назначает id и т.д. )
        public void startSetup(int id)
        {
            this.id = id;
            this.name = generateName(); // генерируем имя по айди
        }

        public void setFFLabel(int x, int y)
        {
            int newX = x;
            int newY = y;
            ffLabel = new Vec2(x, y);
        }

        // этот метод генерирует имя пути из его номера ( нужно для выпадающего списка )
        public string generateName()
        {
            string gName;
            gName = "Ребро " + id.ToString();
            return gName;
        }

        // этот метод возвращает сумму значений всех успешно пройденных потоков
        public int getSuccessFlowsSum()
        {
            int sum = 0;
            foreach (int sf in successFlows)
                sum += sf;
            return sum;
        }

 // этот метод получает левую или правую пропускную способность 
        // исходя из расположения узлов
        public int getCorrectFlowValueByDir(GraphNode n1, GraphNode n2)
        {
            if (ffLabel.x.GetType() == typeof(int) && nodeTo == n2)
                return ffLabel.x;
            else if (ffLabel.y.GetType() == typeof(int) && nodeFrom == n2)
                return ffLabel.y;
            else
                return 0;
        }
        // этот метод находит центр линии изображающее ребро
        // для того чтобы посередине отобразить его пропускную способность
        public Vec2 getLineCenter()
        {
            Vec2 centerPos = new Vec2(0,0);

            // ищем середину отрезка по формуле 
            // centerX = (x1 + x2)/2 , centerY = (y1 + y2)/2 
            centerPos.x = (nodeFrom.pos.x + nodeTo.pos.x) / 2;
            centerPos.y = (nodeFrom.pos.y + nodeTo.pos.y) / 2;
            
            return centerPos;
        }
    }

    public class GraphUtils
    {
        // создаём объект транспортной сети
        public TransportWeb tWeb = new TransportWeb();
    }
}
