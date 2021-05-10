using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphDiplom {
    public partial class MainForm: Form {
        // создаём объект gUtils из которого доступны операции с транспортной сетью/графами/рёбрами
        GraphUtils gUtils = new GraphUtils();

        // содержит расстояние x y на которое будет смещаться графика при отрисовке
        Vec2 startOffset = new Vec2(15, 15);

        public MainForm() {
            InitializeComponent();

            textAnalyseInfo.Visible = false;
        }

        //// МЕТОДЫ ДЛЯ ОТРИСОВКИ ГРАФИКИ ////
        // обновить (очистить и нарисовать заново) холст
        public void updateCanvas() {
            // делаем неактивным панель управления узлом 
            // если ни один узел не выбран
            GraphNode sNode = gUtils.tWeb.findSelectedNode();
            if (sNode == null)
                panelNodeControl.Enabled = false;
            else
                panelNodeControl.Enabled = true;

            // обновляем холст
            Canvas.Invalidate();
        }
        // этот метод позволяет рисовывать графику на панели
        private void Canvas_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            // задаём шрифты
            Font f = new Font(FontFamily.GenericMonospace, 13.0 F, FontStyle.Bold);
            Font f2 = new Font(FontFamily.GenericSansSerif, 10.0 F, FontStyle.Bold);

            // рисуем пути между узлами
            if (gUtils.tWeb.allPaths.Count() > 0) {
                for (int i = 0; i < gUtils.tWeb.allPaths.Count(); i++) {
                    GraphPath p = gUtils.tWeb.allPaths[i];

                    // рисуем линию между узлами
                    Color lineColor;
                    // если ребро выбрано меняем её цвет
                    if (p.isSelected)
                        lineColor = Color.DeepPink;
                    else
                        lineColor = Color.LightGray;

                    g.DrawLine(
                        new Pen(new SolidBrush(lineColor), 3.0 F),
                        new Point(p.nodeFrom.pos.x, p.nodeFrom.pos.y),
                        new Point(p.nodeTo.pos.x, p.nodeTo.pos.y));

                    // рисуем пропускную способность 
                    string onLineText;

                    if (p.ffLabel.x.GetType() != typeof (int) && p.ffLabel.x == FastMath.SYMBOLS.UNKNOWN)
                        onLineText = "?/?";
                    else
                        onLineText = Convert.ToString(p.ffLabel.x) + "/" + Convert.ToString(p.ffLabel.y);

                    g.DrawString(
                        onLineText, f, new SolidBrush(Color.Black),
                        p.getLineCenter().x, p.getLineCenter().y);
                }
            }
            // рисуем узлы
            if (gUtils.tWeb.allNodes.Count() > 0) {
                // отрисовываем все узлы в транспортной сети ( класс tWeb в GraphUtils )
                for (int i = 0; i < gUtils.tWeb.allNodes.Count(); i++) {
                    GraphNode n = gUtils.tWeb.allNodes[i];
                    // рисуем узел в виде эллипса

                    Rectangle ellipseRect = new Rectangle(
                        n.getCenterPos().x, n.getCenterPos().y,
                        n.size.x, n.size.y
                    );

                    // если узел выбран закрашиваем тёмным цветом
                    // иначе белым
                    if (n.isSelected)
                        g.FillEllipse(new SolidBrush(Color.LightPink), ellipseRect);
                    else
                        g.FillEllipse(new SolidBrush(Color.White), ellipseRect);
                    // если узел исток - рисуем его зелёным + делаем обводку круга больше
                    // если узел сток - рисуем его красным + делаем обводку круга больше
                    // иначе узел синий
                    Color ellipseColor;
                    float outlineWidth;

                    if (n.isStart) {
                        ellipseColor = Color.LawnGreen;
                        outlineWidth = 4.3 F;
                    } else if (n.isFinish) {
                        ellipseColor = Color.PaleVioletRed;
                        outlineWidth = 4.3 F;
                    } else {
                        ellipseColor = Color.Blue;
                        outlineWidth = 2.5 F;
                    }
                    Pen ellipsePen = new Pen(new SolidBrush(ellipseColor), outlineWidth);

                    g.DrawEllipse(ellipsePen, ellipseRect);

                    // внутри круга пишем его номер
                    string nodeBaseInfo = n.num.ToString();
                    // если задано поглощение, отображаем его тоже
                    if (n.absorption != 0)
                        nodeBaseInfo += "\r" + "\n" + "(" + Convert.ToString(n.absorption) + ")";

                    g.DrawString(
                        nodeBaseInfo, f, new SolidBrush(Color.Black),
                        n.getCenterPos().x + 3, n.getCenterPos().y + 3);

                    // пишем метки узла из алгоритма Форда-Фалкерсона
                    if (n.ffLabel == null) {
                        g.DrawString(
                            "[ ... ]", f2, new SolidBrush(Color.IndianRed),
                            n.getCenterPos().x, n.getCenterPos().y + n.size.x);
                    } else {
                        Vec2 ffTextLabel = new Vec2(Convert.ToString(n.ffLabel.x), Convert.ToString(n.ffLabel.y));

                        if (n.ffLabel.x.GetType() != typeof (int) && n.ffLabel.x == FastMath.SYMBOLS.INF)
                            ffTextLabel.x = "∞";
                        if (n.ffLabel.y.GetType() != typeof (int) && n.ffLabel.y == FastMath.SYMBOLS.DASH)
                            ffTextLabel.y = "-";
                        if (n.ffLabel.x.GetType() != typeof (int) && n.ffLabel.x == FastMath.SYMBOLS.REMOVED) {
                            ffTextLabel.x = "xXx";
                            ffTextLabel.y = "xXx";
                        }

                        g.DrawString(
                            "[" + ffTextLabel.x + ", " + ffTextLabel.y + "]",
                            f2, new SolidBrush(Color.Maroon),
                            n.getCenterPos().x, n.getCenterPos().y + n.size.x);
                    }
                }
            }

            g.Dispose();
        }

        // обработка кликов мыши
        private void Canvas_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                // ищем узел близкий к позиции мыши в момент клика
                GraphNode n = gUtils.tWeb.findNearestNodeToPos(new Vec2(e.Location.X, e.Location.Y));
                // если такого нет
                if (n == null) {
                    //labelHeader.Text = e.Location.X.ToString() + " " + e.Location.Y.ToString();
                    labelNodeDesc.Text = "Узел не найден";
                    butMakeNodeStart.Enabled = false;
                    butMakeNodeFinish.Enabled = false;
                }
                // если есть
                else {
                    gUtils.tWeb.selectNode(n);
                    labelNodeDesc.Text = "Выбран: Узел " + n.num.ToString();
                    butMakeNodeStart.Enabled = true;
                    butMakeNodeFinish.Enabled = true;

                    textNodeAbsoValue.Text = Convert.ToString(n.absorption);

                    // находим все связанные рёбра и добавляем их в 
                    // выпадающий список для редактирования
                    List < GraphPath > nodePaths = gUtils.tWeb.findAllPathsInNode(n);
                    if (nodePaths.Count() > 0) {
                        // очищаем прошлые данные из списка
                        comboNodePaths.Items.Clear();
                        // добавляем новые
                        for (int i = 0; i < nodePaths.Count(); i++)
                            comboNodePaths.Items.Add(nodePaths[i].name);
                    }
                    updateCanvas();
                }
            }

            // если нажата правая кнопка, добавляем узел
            else if (e.Button == MouseButtons.Right) {
                // убираем приветственную надпись
                labelWelcome.Hide();

                // ищем узел близкий к позиции мыши в момент клика
                GraphNode otherN = gUtils.tWeb.findNearestNodeToPos(new Vec2(e.Location.X, e.Location.Y));

                // если такого нет
                if (otherN == null) {
                    // добавляем объект узла в массив-список в класс транспортной сети
                    // координаты узла равны координатам курсора мыши в момент клика
                    GraphNode n = gUtils.tWeb.addNode(new GraphNode(new Vec2(e.Location.X, e.Location.Y)));
                    gUtils.tWeb.selectNode(n);

                }
                // если есть, соединяем узлы
                else {
                    GraphNode selectedNode = gUtils.tWeb.findSelectedNode();
                    if (selectedNode == null) {
                        MessageBox.Show(
                            "Чтобы соединить узлы, нужно сначала выбрать узел (ЛКМ), и нажать ПКМ на другом");
                    } else {
                        gUtils.tWeb.connectNodes(selectedNode, otherN);
                    }
                }
                updateCanvas();
            }
        }

        // нажата кнопка "сделать истоком"
        private void butMakeNodeStart_Click(object sender, EventArgs e) {
            GraphNode selectedNode = gUtils.tWeb.findSelectedNode();
            if (selectedNode != null) {
                gUtils.tWeb.makeNodeStart(selectedNode);

                updateCanvas();
            }
        }

        // нажата кнопка "сделать стоком"
        private void butMakeNodeFinish_Click(object sender, EventArgs e) {
            GraphNode selectedNode = gUtils.tWeb.findSelectedNode();
            if (selectedNode != null) {
                gUtils.tWeb.makeNodeFinish(selectedNode);

                updateCanvas();
            }
        }

        // выбран узел в выпадающем списке
        private void comboNodePaths_SelectedIndexChanged(object sender, EventArgs e) {
            string selectedPathName = comboNodePaths.SelectedItem.ToString();
            labelSelectedPath.Text = "Выбрано: " + selectedPathName;
            // ищем узел с таким именем в транспортной сети и выбираем его
            GraphPath foundPath = gUtils.tWeb.findPathByName(selectedPathName);
            if (foundPath != null) {
                // выставялем значение пропускной способности в textbox ( если нет ставим 0 )
                if (foundPath.ffLabel.x.GetType() != typeof (int) && foundPath.ffLabel.x == FastMath.SYMBOLS.UNKNOWN) {
                    textPathFFValue.Text = "0";
                    textPathFFValue2.Text = "0";
                } else {
                    textPathFFValue.Text = Convert.ToString(foundPath.ffLabel.x);
                    textPathFFValue2.Text = "0";
                }

                butSetupPathFF.Enabled = true;
                textPathFFValue.Enabled = true;
                textPathFFValue2.Enabled = true;

                gUtils.tWeb.selectPath(foundPath);
                updateCanvas();

            } else {
                butSetupPathFF.Enabled = false;
                textPathFFValue.Enabled = false;
                textPathFFValue2.Enabled = false;
            }
        }

        // нажата кнопка "задать пропускную способность ребра"
        private void butSetupPathFF_Click(object sender, EventArgs e) {
            GraphPath selectedPath = gUtils.tWeb.findSelectedPath();
            if (selectedPath != null) {
                string newValue = textPathFFValue.Text;
                string newValue2 = textPathFFValue2.Text;

                int convertedValue, convertedValue2;

                // проверям ввёл ли пользователь число
                try {
                    convertedValue = Convert.ToInt32(newValue);
                } catch {
                    MessageBox.Show(
                        "Ошибка! Пропускную способность нужно указывать целым числом INT");

                    return; // прерываем работу функции
                }
                try {
                    convertedValue2 = Convert.ToInt32(newValue2);
                } catch {
                    MessageBox.Show(
                        "Ошибка! Пропускную способность нужно указывать целым числом INT");

                    return; // прерываем работу функции
                }

                selectedPath.ffLabel.x = convertedValue;
                selectedPath.ffLabel.y = convertedValue2;
                updateCanvas();
            } else {
                MessageBox.Show("Сначала выберите ребро для редактирования!");
            }
        }

        // нажата кнопка "расставить случайную пропускную способность"
        private void butSetupRandomFFValue_Click(object sender, EventArgs e) {
            // выставляем случайное значение пропускной способности каждому ребру
            for (int i = 0; i < gUtils.tWeb.allPaths.Count(); i++) {

                GraphPath curPath = gUtils.tWeb.allPaths[i];
                if (curPath.ffLabel.x.GetType() != typeof (int) && curPath.ffLabel.x == FastMath.SYMBOLS.UNKNOWN) {
                    curPath.ffLabel.x = FastMath.genRandom(0, 10);
                    curPath.ffLabel.y = 0;
                }
                updateCanvas();
            }

        }

        // нажата кнопка "очистить"
        private void butClearCanvas_Click(object sender, EventArgs e) {
            // очищает холст и удаляет данные из класса транспортной сети
            gUtils.tWeb.clearWeb();
            updateCanvas();
        }

        // нажата кнопка "Расчёты"
        private void butAnalyseInfo_Click(object sender, EventArgs e) {
            // если textbox с расчётами открыт - закрываем его, и наоборот
            if (textAnalyseInfo.Visible)
                textAnalyseInfo.Visible = false;
            else
                textAnalyseInfo.Visible = true;
        }

        // эта функция проверяет все данные для правильной работы алгоритма
        // и если всё нормально находит и выводит результат в одну из вкладок результатов
        public void analyseWebWithFordFalc(int exNumber,
            bool withIntervals = false, bool withAbsorption = false, bool onlyMinFlow = false) {
            int result = gUtils.tWeb.calculateFordFalk(withIntervals, withAbsorption, onlyMinFlow);
            if (result == -1)
                MessageBox.Show("Недостаточно данных! Для расчёта нужно указать исток и сток," +
                    " а также расставить пропускную способность на рёбрах ( или нажать кнопку " +
                    " 'сгенерировать проп. способ. случайно' )");
            else {
                if (exNumber == 1)
                    labelEx1Result.Text = Convert.ToString(result);
                else if (exNumber == 2)
                    labelEx2Result.Text = Convert.ToString(result);
                else if (exNumber == 3)
                    labelEx3Result.Text = Convert.ToString(result);
                //else if (exNumber == 4)
                //{
                //   labelEx4ResultMinF.Text = Convert.ToString(result);
                //   labelEx4ResultHistory.Text = gUtils.tWeb.minFlowHistory;
                // }
                textAnalyseInfo.Text = gUtils.tWeb.descFordFalk;
                textAnalyseInfo.Visible = true;
                updateCanvas();
            }
        }
        // нажата кнопка "сохранить поглощение узла"
        private void butNodeSaveAbso_Click(object sender, EventArgs e) {
            // ищем выбранный узел и если такой есть
            // продолжаем работу функции
            GraphNode selectedNode = gUtils.tWeb.findSelectedNode();
            if (selectedNode != null) {

                // получаем значение из текстового поля
                string newValue = textNodeAbsoValue.Text;

                int convertedValue;

                // проверям ввёл ли пользователь число
                try {
                    convertedValue = Convert.ToInt32(newValue);
                } catch {
                    MessageBox.Show(
                        "Ошибка! Поглощение узла нужно указывать целым числом INT");

                    return; // прерываем работу функции
                }

                // задаём выбранному узлу значение поглощение
                selectedNode.absorption = convertedValue;
                updateCanvas();
            } else {
                MessageBox.Show("Узел не выбран!");
            }
        }

        ////// нажата кнопка рассчитать "max пропускную способность" //////
        // ЗАДАНИЕ 1 //
        private void butEx1CalcFordFalk_Click(object sender, EventArgs e) {
            analyseWebWithFordFalc(1, false);
        }

        // ЗАДАНИЕ 2 //
        private void butEx2CalcFordFalk_Click(object sender, EventArgs e) {
            analyseWebWithFordFalc(2, true);
        }

        // ЗАДАНИЕ 3 //
        private void butEx3CalcFordFalk_Click(object sender, EventArgs e) {
            analyseWebWithFordFalc(3, false, true);
        }

    }
}