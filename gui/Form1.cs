/*  
 *  This is the GUI software for visualizing the counts read from the
 *  Geiger-Mueller Counter via the USB interface program.
 *  
 *  Date: 2014-05-19
 *  Author: Phillip Durdaut
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;
using System.Diagnostics;
using ZedGraph;

namespace GeigerMuellerCounter
{
    public partial class Form1 : Form
    {
        private UInt64 i = 0;
        private UInt64 m_Counts = 0;
        private bool m_FirstData = true;
        private DateTime m_dateTimeFirstData;
        private bool m_Started = false;

        GraphPane m_GraphPaneCounts;
        PointPairList m_PointPairListCounts = new PointPairList();
        
        public Form1()
        {
            InitializeComponent();

            m_GraphPaneCounts = m_ZedGraphControlCounts.GraphPane;
            m_GraphPaneCounts.Title.Text = "Abgerufene Counts vom Geiger-Mueller-Zaehler [Counts/(" + (m_Timer.Interval/1000) + " s)]";
            m_GraphPaneCounts.XAxis.Title.Text = "Zeit in s";
            m_GraphPaneCounts.YAxis.Title.Text = "";
            m_GraphPaneCounts.YAxis.MajorGrid.IsVisible = true;

            LineItem lineItemVBatHigh = m_GraphPaneCounts.AddCurve("Counts", m_PointPairListCounts, Color.Blue, SymbolType.None);
            lineItemVBatHigh.Symbol.IsVisible = false;
        }

        private delegate void AddGraphDataDelegate(UInt64 p_Counts);
        private void AddGraphData(UInt64 p_Counts)
        {
            if (this.InvokeRequired) {
                this.BeginInvoke(new AddGraphDataDelegate(AddGraphData), new object[] { p_Counts });
                return;
            }

            TimeSpan timeSpan = DateTime.Now - m_dateTimeFirstData;
            double seconds = timeSpan.TotalSeconds;

            m_PointPairListCounts.Add(seconds, p_Counts);
            m_ZedGraphControlCounts.AxisChange();
            m_ZedGraphControlCounts.Refresh();
            GraphLimitation(m_PointPairListCounts, 1000);

            i++;
        }

        private void GraphLimitation(PointPairList p_PointPairList, int p_Limit)
        {
            if (p_PointPairList.Count > p_Limit)
            {
                do
                {
                    p_PointPairList.RemoveAt(0);
                }
                while (p_PointPairList.Count > p_Limit);
            }
        }

        private UInt64 GetCountsFromDevice()
        {
            UInt64 count = 0;
            
            Process myProcess = new Process();
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("usb_command", "get");
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            myProcess.Start();
            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadLine();
            myProcess.WaitForExit();
            myProcess.Close();

            try
            {
                count = Convert.ToUInt64(myString);
            }
            catch
            {
            }

            return count;
        }

        private void m_ButtonStartStop_Click(object sender, EventArgs e)
        {
            if (!m_Started)
            {
                m_ButtonStartStop.Text = "Stop";
                m_Timer.Enabled = true;
                m_Started = true;
            }
            else
            {
                m_ButtonStartStop.Text = "Start";
                m_Timer.Enabled = false; 
                m_Started = false;
            }
        }

        private void m_Timer_Tick(object sender, EventArgs e)
        {
            if (m_FirstData)
            {
                m_dateTimeFirstData = DateTime.Now;
                m_FirstData = false;
            }

            m_Counts = GetCountsFromDevice();
            AddGraphData(m_Counts);
        }
    }
}
