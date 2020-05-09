﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiriosApplication
{
   public partial class ApplicationForm : Form
   {
      //TODO: Include status message
      //TODO: Implement protocol checking (make sure that the message received is protocol-compliant)
      //TODO: Take values from corrupt messages (so that when only one sensor breaks the others keep giving readings)
      Thread serverThread;

      public ApplicationForm()
      {
         InitializeComponent();
         lbDate.Text = DateTime.Now.ToLongDateString(); // Set date
         lbTime.Text = DateTime.Now.ToShortTimeString(); // Set time
         ToolTip toolTip = new ToolTip // Create ToolTip and associate with the Form container
         {
            InitialDelay = 1000, // Milliseconds transpired before appearing
            ShowAlways = true // Force ToolTip text to display
         };
         // Set all necessary ToolTips
         toolTip.SetToolTip(lbDate, "Current date");
         toolTip.SetToolTip(lbTime, "Current time");
         toolTip.SetToolTip(picTemp, "Temperature in degrees Celsius");
         toolTip.SetToolTip(lbTemp, "Temperature in degrees Celsius");
         toolTip.SetToolTip(picHumid, "Relative humidity in percentages");
         toolTip.SetToolTip(lbHumid, "Relative humidity in percentages");
         toolTip.SetToolTip(picTVOC, "Total volatile organic compounds in parts-per-billion");
         toolTip.SetToolTip(lbTVOC, "Total volatile organic compounds in parts-per-billion");
         toolTip.SetToolTip(picCO2, "Carbon dioxide in parts-per-million");
         toolTip.SetToolTip(lbCO2, "Carbon dioxide in parts-per-million");
         toolTip.SetToolTip(picIP, "Current IP being displayed\nClick on any icon or value to switch between modules");
         toolTip.SetToolTip(lbIP, "Current IP being displayed\nClick on any icon or value to switch between modules");
      }

      private void timer_Tick(object sender, EventArgs e)
      {
         lbDate.Text = DateTime.Now.ToLongDateString(); // Set date
         lbTime.Text = DateTime.Now.ToShortTimeString(); // Set time

         // TODO: once first module connected, display its values. If disconnected, display initial values (all 0's)
         if (Readings.Co2.Count != 0 && Readings.Humidity.Count != 0 && Readings.Voc.Count != 0 && Readings.Temperature.Count != 0)
         {
            lbCO2.Text = Readings.Co2[Readings.Co2.Count - 1].ToString() + " ppm";
            lbTemp.Text = Readings.Temperature[Readings.Temperature.Count - 1].ToString() + "℃";
            lbHumid.Text = Readings.Humidity[Readings.Humidity.Count - 1].ToString() + "%";
            lbTVOC.Text = Readings.Voc[Readings.Voc.Count - 1].ToString() + " ppb";
         }
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Server server = new Server();
         serverThread = new Thread(server.Run);
         serverThread.Start();
      }

      private void btnMore_Click(object sender, EventArgs e)
      {
         StatisticsForm statisticsForm = new StatisticsForm(); // Create new form
         statisticsForm.ShowDialog(); // Show form            
      }

      private void ApplicationForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         Readings.ShouldStop = true;
         serverThread.Abort();
      }

      private void SwitchValues()
      {
         // TODO: display values of possible other connected modules
         lbTemp.Text = "clicked";
         lbHumid.Text = "clicked";
         lbTVOC.Text = "clicked";
         lbCO2.Text = "clicked";
         lbIP.Text = "clicked";
      }

      private void picTemp_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void picHumid_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void picTVOC_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void picCO2_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void picIP_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void lbTemp_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void lbHumid_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void lbTVOC_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void lbCO2_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void lbIP_MouseClick(object sender, MouseEventArgs e)
      {
         SwitchValues();
      }

      private void btnFan_Click(object sender, EventArgs e)
      {
         VentilationForm ventilationForm = new VentilationForm();
         ventilationForm.ShowDialog();
      }
   }
}
