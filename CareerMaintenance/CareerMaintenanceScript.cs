using CareerMaintenance;
using CareerNamespace;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace CareerAutomationTests
{

    public static class CareerMaintenanceScript
    {
        //This is valid for FullScreen and Resolution 3840x2160
        const int cReferenceScreenWidth = 3840;
        const int cReferenceScreenHeight = 2160;

        //All Company Screen
        static CareerPosAndColor cAllCompanyIdentifyActiveFirstTopLeft = new CareerPosAndColor(112, 396, 59, 132, 235);
        static CareerPosAndColor cAllCompanyIdentifyInactiveFirstTopLeft = new CareerPosAndColor(112, 396, 63, 120, 200);
        static CareerPosAndColor cAllCompanyIdentifySelectedFirstTopLeft = new CareerPosAndColor(112, 396, 203, 203, 203);//203+/-52

        static CareerPosAndColor cAllCompanyIdentifyActiveFirstBottomLeft = new CareerPosAndColor(112, 500, 59, 132, 235);
        static CareerPosAndColor cAllCompanyIdentifyInactiveFirstBottomLeft = new CareerPosAndColor(112, 500, 60, 110, 185);
        static CareerPosAndColor cAllCompanyIdentifySelectedFirstBottomLeft = new CareerPosAndColor(112, 500, 203, 203, 203);//203+/-52

        static CareerPosAndColor cAllCompanyIdentifyActiveFirstBottomRigth = new CareerPosAndColor(682, 500, 25, 56, 100);//Checkmark
        static CareerPosAndColor cAllCompanyIdentifyInactiveFirstBottomRight = new CareerPosAndColor(682, 500, 69, 109, 170); //No Checkmark
        static CareerPosAndColor cAllCompanyIdentifySelectedFirstBottomRight = new CareerPosAndColor(682, 500, 25, 56, 100);//Checkmark

        static CareerPosAndColor cAllCompanyIdentifyActiveSecondBottomLeft = new CareerPosAndColor(112, 660, 59, 132, 235);
        static CareerPosAndColor cAllCompanyIdentifyInactiveSecondBottomLeft = new CareerPosAndColor(112, 660, 60, 110, 185);
        static CareerPosAndColor cAllCompanyIdentifySelectedSecondBottomLeft = new CareerPosAndColor(112, 660, 203, 203, 203);//203+/-52

        static CareerPosAndColor cAllCompanyIdentifyActiveThirdBottomLeft = new CareerPosAndColor(112, 828, 59, 132, 235);
        static CareerPosAndColor cAllCompanyIdentifyInactiveThirdBottomLeft = new CareerPosAndColor(112, 828, 60, 110, 185);
        static CareerPosAndColor cAllCompanyIdentifySelectedThirdBottomLeft = new CareerPosAndColor(112, 828, 203, 203, 203);//203+/-52

        static CareerPosAndColor cVerticalBarUpperEndInnerInactive = new CareerPosAndColor(3730, 900, 89, 92, 97);
        static CareerPosAndColor cVerticalBarUpperEndInnerActive = new CareerPosAndColor(3730, 900, 59, 132, 235);
        static CareerPosAndColor cVerticalBarUpperEndOuter = new CareerPosAndColor(3730, 880, 61, 65, 72);
        static CareerPosAndColor cVerticalBarLowerEndInnerInactive = new CareerPosAndColor(3730, 2012, 121, 115, 112);
        static CareerPosAndColor cVerticalBarLowerEndInnerActive = new CareerPosAndColor(3730, 2012, 59, 132, 235);
        static CareerPosAndColor cVerticalBarLowerEndOuter = new CareerPosAndColor(3730, 2030, 124, 111, 105);


        //Single Company and Maintenance Screen
        static CareerPosAndColor cCompanyIdentifyActive = new CareerPosAndColor(125, 85, 255, 255, 255);
        static CareerPosAndColor cCompanyIdentifySplashScreen = new CareerPosAndColor(125, 85, 153, 153, 153);
        static CareerPosAndColor cMaintenanceIdentifyActive = new CareerPosAndColor(250, 270, 255, 255, 255);

        static CareerPosAndColor cHorizontalBarLeftEndInnerInactive = new CareerPosAndColor(1382, 1920, 112, 107, 107);
        static CareerPosAndColor cHorizontalBarLeftEndInnerActive = new CareerPosAndColor(1382, 1920, 59, 132, 235);
        static CareerPosAndColor cHorizontalBarLeftEndOuter = new CareerPosAndColor(1372, 1920, 117, 105, 101);
        static CareerPosAndColor cHorizontalBarRightEndInnerInactive = new CareerPosAndColor(3395, 1920, 90, 90, 93);
        static CareerPosAndColor cHorizontalBarRightEndInnerActive = new CareerPosAndColor(3395, 1920, 59, 132, 235);
        static CareerPosAndColor cHorizontalBarRightEndOuter = new CareerPosAndColor(3405, 1920, 61, 62, 66);

        static CareerPosAndColor cBuyAricraftActive = new CareerPosAndColor(130, 995, 255, 255, 255);
        static CareerPosAndColor cBuyAricraftInactive = new CareerPosAndColor(130, 995, 255, 222, 3);

        static CareerPosAndColor cFirstAircraftNonExist = new CareerPosAndColor(1100, 1800, 110, 96, 88);
        static CareerPosAndColor cFirstAricraftExistAndInactie = new CareerPosAndColor(1100, 1800, 124, 120, 135);
        static CareerPosAndColor cFirstAircraftExistAndActive = new CareerPosAndColor(1100, 1800, 203, 203, 203); //203+/-52 (185,185,186)

        static CareerPosAndColor cSecondAricraftExistAndInactie = new CareerPosAndColor(1850, 1800, 124, 120, 135);
        static CareerPosAndColor cThirdAricraftExistAndInactie = new CareerPosAndColor(2600, 1800, 124, 120, 135);
        static CareerPosAndColor cFourthAricraftExistAndInactie = new CareerPosAndColor(3350, 1800, 124, 120, 135);

        static CareerPosAndColor cSecondAricraftExistAndActive = new CareerPosAndColor(1850, 1800, 203, 203, 203);//203+/-52
        static CareerPosAndColor cThirdAricraftExistAndActive = new CareerPosAndColor(2600, 1800, 203, 203, 203);//203+/-52

        static CareerPosAndColor cNthAricraftExistAndInactie = new CareerPosAndColor(3030, 1800, 124, 120, 135);
        static CareerPosAndColor cNthAricraftExistAndActive = new CareerPosAndColor(3030, 1800, 203, 203, 203);//203+/-52

        static CareerPosAndColor cLastAricraftExistAndInactie = new CareerPosAndColor(2990, 1800, 124, 120, 135);
        static CareerPosAndColor cLastAricraftExistAndActive = new CareerPosAndColor(2990, 1800, 203, 203, 203);//203+/-52

        static CareerPosAndColor cFirstAircraftOpenSubMenuInactive = new CareerPosAndColor(1088, 1828, 52, 111, 195);
        static CareerPosAndColor cFirstAircraftOpenSubMenuActive = new CareerPosAndColor(1088, 1828, 203, 203, 203);//203+/-52
        static CareerPosAndColor cSecondAircraftOpenSubMenuActive = new CareerPosAndColor(1838, 1828, 203, 203, 203);//203+/-52
        static CareerPosAndColor cThirdAircraftOpenSubMenuActive = new CareerPosAndColor(2588, 1828, 203, 203, 203);//203+/-52
        static CareerPosAndColor cNthAircraftOpenSubMenuActive = new CareerPosAndColor(3028, 1828, 203, 203, 203);//203+/-52
        static CareerPosAndColor cLastAircraftOpenSubMenuActive = new CareerPosAndColor(2978, 1828, 203, 203, 203);//203+/-52

        static CareerPosAndColor cFirstAircraftOpenSubMenuBottom = new CareerPosAndColor(1088, 1959, 48, 106, 189);
        static CareerPosAndColor cSecondAircraftOpenSubMenuBottom = new CareerPosAndColor(1838, 1959, 48, 106, 189);
        static CareerPosAndColor cThirdAircraftOpenSubMenuBottom = new CareerPosAndColor(2588, 1959, 48, 106, 189);
        static CareerPosAndColor cNthAircraftOpenSubMenuBottom = new CareerPosAndColor(3028, 1959, 48, 106, 189);
        static CareerPosAndColor cLastAircraftOpenSubMenuBottom = new CareerPosAndColor(2978, 1959, 48, 106, 189);

        static CareerPosAndColor cWashInactive = new CareerPosAndColor(190, 1730, 33, 50, 68);
        static CareerPosAndColor cWashActive = new CareerPosAndColor(190, 1730, 37, 89, 158);
        static CareerPosAndColor cWashSelected = new CareerPosAndColor(190, 1730, 203, 203, 203);  //203+/-52 (232,232,232)

        static CareerPosAndColor cCheckUpInactive = new CareerPosAndColor(190, 1535, 59, 90, 96);
        static CareerPosAndColor cCheckUpActive = new CareerPosAndColor(190, 1535, 53, 78, 137);
        static CareerPosAndColor cCheckUpSelected = new CareerPosAndColor(190, 1535, 203, 203, 203);  //203+/-52 (232,232,232)

        static CareerPosAndColor cDelegateInactive = new CareerPosAndColor(765, 1535, 25, 48, 64);
        static CareerPosAndColor cDelegateActive = new CareerPosAndColor(765, 1535, 28, 77, 142);
        static CareerPosAndColor cDelegateSelected = new CareerPosAndColor(765, 1535, 203, 203, 203);  //203+/-52 (232,232,232)

        //Screen/UI Offset and Scaling
        static double sScreenCenterX = 0.0;
        static double sScreenCenterY = 0.0;
        static double sUIScaleing = 1.0;


        static object sLock = new object();
        static bool sIsRunning = false;
        static string sStatus = string.Empty;
        static string sProgressLabelStatus = string.Empty;
        static bool sStopRequested = false;
        static Thread sThread = null;

        static int sCompanyNr = 1;
        static int sPlaneNr = 1;


        public static void StartScript()
        {
            lock (sLock)
            {
                if (sIsRunning)
                {
                    return;
                }
                sThread = new Thread(ScriptExecute);
                //sThread.IsBackground = true;
                sThread.Start();
            }
        }

        public static bool IsScriptRunning()
        {
            lock (sLock)
            {
                if (sIsRunning)
                {
                    return true;
                }
                return false;
            }
        }

        public static string GetStatus()
        {
            lock (sLock)
            {
                return sStatus;
            }
        }

        public static string GetProgressLabelStatus()
        {
            lock (sLock)
            {
                return sProgressLabelStatus;
            }
        }


        public static void KillTask()
        {
            bool vHaveToWait = false;

            if (IsScriptRunning())
            {
                sStopRequested = true;
                vHaveToWait = true;
            }

            if (vHaveToWait)
            {
                int vMaxWait = 20;
                for (int vWait = 1; vWait <= vMaxWait; vWait++)
                {
                    if (!IsScriptRunning())
                    {
                        break;
                    }
                    Thread.Sleep(500);
                }
                if (IsScriptRunning())
                {
                    sThread.Abort();
                }

            }
        }

        public static int GetCompanyNr()
        {
            int vCompanyNr = 0;
            lock (sLock)
            {
                vCompanyNr = sCompanyNr;
            }
            return vCompanyNr;
        }

        public static int GetPlaneNr()
        {
            int vPlaneNr = 0;
            lock (sLock)
            {
                vPlaneNr = sPlaneNr;
            }
            return vPlaneNr;
        }

        public static void SetStatus(string iTheStatus)
        {
            lock (sLock)
            {
                sStatus = iTheStatus;
            }
        }

        public static void SetFullStatus(string iTheStatus)
        {
            lock (sLock)
            {
                sStatus = iTheStatus;
                sProgressLabelStatus = CreateProgressLabel(sCompanyNr, sPlaneNr);
            }
        }


        public static void ResetCompanyNr()
        {
            lock (sLock)
            {
                sCompanyNr = 1;
                sPlaneNr = 1;
            }
        }

        public static void IncrementCompanyNr()
        {
            lock (sLock)
            {
                sCompanyNr++;
                sPlaneNr = 1;
            }
        }

        public static void SetPlaneCounter(int iPlaneNr)
        {
            lock (sLock)
            {
                sPlaneNr = iPlaneNr;
            }
        }

        public static void SetProgressLabel(string iText)
        {
            lock (sLock)
            {
                sProgressLabelStatus = iText;
            }
        }

        private static string CreateProgressLabel(int iCompanyNr, int iPlaneNr)
        {
            string vProgressLabelText = "Comp " + iCompanyNr.ToString() + " Plane " + iPlaneNr.ToString();
            return vProgressLabelText;
        }

        public static void Stop()
        {
            lock (sLock)
            {
                if (sIsRunning)
                {
                    sStopRequested = true;
                }
            }
            while (IsScriptRunning())
            {
                Thread.Sleep(100);
            }
        }

        public static void Reset()
        {
            lock (sLock)
            {
                if (sIsRunning)
                {
                    sStopRequested = true;
                }
            }
            while (IsScriptRunning())
            {
                Thread.Sleep(100);
            }
            ResetCompanyNr();
            lock (sLock)
            {
                sStopRequested = false;
                sStatus = string.Empty;
                sProgressLabelStatus = "Ready";
            }
        }

        public static bool IsStopRequested()
        {
            lock (sLock)
            {
                if (sStopRequested)
                {
                    return true;
                }
                return false;
            }
        }

        public static void ScriptExecute()
        {
            try
            {
                //Keys
                string vKeyEscape = "{ESC}";
                string vKeyLeft = "{LEFT}";
                string vKeyRight = "{RIGHT}";
                string vKeyUp = "{UP}";
                string vKeyDown = "{DOWN}";
                string vKeySpace = " ";
                //string vKeyEnter = "{ENTER}";

                CareerNamespace.CareerAutomation vCareer = null;


                //Attach to Career
                vCareer = CareerNamespace.CareerAutomation.AttachToRunningCareer();
                if (null == vCareer)
                {
                    SetStatus("No running FS2024!");
                    return;
                }
                Thread.Sleep(1000);

                int vTopLeftX = 0;
                int vTopLeftY = 0;
                int vWidth = 0;
                int vHeight = 0;

                CareerNamespace.CareerAutomation.GetWindowsClient(out vTopLeftX,
                                                                  out vTopLeftY,
                                                                  out vWidth,
                                                                  out vHeight);

                //vCareer.GetWindowBorders(out vTopLeftX, out vTopLeftY, out vWidth, out vHeight);

                //if ((vTopLeftX != 0) || (vTopLeftY != 0))
                //{
                //    SetStatus("FS2024 has torun in Full Screen Mode!");
                //    return;
                //}
                //if ((vWidth == 0) || (vHeight == 0))
                //{
                //    SetStatus("FS2024 has to run in Full Screen Mode and have a Size!");
                //    return;
                //}

                //Calculate the Screen Offset and The UIScaling
                sScreenCenterX = (double)(vTopLeftX) + 0.5 * (double)(vWidth);
                sScreenCenterY = (double)(vTopLeftY) + 0.5 * (double)(vHeight);

                //The Ratio has to be 16:9 if not it seems a 16:9 is put inside the Screen whatever the Screen ratio is
                double v16To9Relation = 16.0 / 9.0;
                double vThisRelation = ((double)vWidth / (double)vHeight);

                double cRelationEpsilon = 0.000001;
                if (Math.Abs(vThisRelation - v16To9Relation) < cRelationEpsilon)
                {
                    //16:9 Screen
                    sUIScaleing = (double)(vWidth) / (double)(cReferenceScreenWidth);
                }
                else
                {
                    if (vThisRelation > v16To9Relation)
                    {
                        //Wide Screen
                        sUIScaleing = (double)(vHeight) / (double)(cReferenceScreenHeight);
                    }
                    else
                    {
                        //HeightScreen
                        sUIScaleing = (double)(vWidth) / (double)(cReferenceScreenWidth);
                    }
                }



                //Inital
                //ExternalAction.MoveToPosition(vTopLeftX+5, vTopLeftY+5);
                ExternalAction.MoveToPosition(0, 0);
                Thread.Sleep(100);

                // MouseAction.ClickLeft();
                //vCareer.SendKey(vKeyRight);



                if (!IsInAllCompanyScreen(vCareer))
                {
                    SetStatus("You have to be in the All Companies Screen to start!");
                    return;
                }

                lock (sLock)
                {
                    sStopRequested = false;
                    sIsRunning = true;
                }


                SetStatus("Start");

                //Navigate to the All companies Button (15 max companies but there are only 11)
                for (int vi = 1; vi <= 16; vi++)
                {
                    vCareer.SendKey(vKeyUp);
                    if (IsStopRequested())
                    {
                        SetStatus("Stopped");
                        return;
                    }
                }
                Thread.Sleep(1000);
                vCareer.SendKey(vKeyLeft);
                Thread.Sleep(100);
                vCareer.SendKey(vKeyUp);
                Thread.Sleep(100);
                vCareer.SendKey(vKeyUp);
                Thread.Sleep(100);
                vCareer.SendKey(vKeyUp);
                Thread.Sleep(100);
                if (IsStopRequested())
                {
                    SetStatus("Stopped");
                    return;
                }

                if (!IsInAllCompanyScreenFirstWhiteSelected(vCareer))
                {
                    SetStatus("Could not Select the All Companies Button");
                    lock (sLock)
                    {
                        sStopRequested = false;
                        sIsRunning = false;
                    }
                    return;
                }

                //We abort when there was no progress after one retry

                int vLastFailedCompanyNr = 0;
                int vLastFailedPlaneNr = 0;

                bool vIsLastCompany = false;

                while (!vIsLastCompany)
                {

                    if (IsStopRequested())
                    {
                        SetStatus("Stopped");
                        return;
                    }

                    int vCompanyNr = GetCompanyNr();

                    //The All companie should be active and selected
                    vCareer.SendKey(vKeyRight);
                    Thread.Sleep(200);
                    //Now we should be on the first company

                    for (int vSelectingCompany = 2; vSelectingCompany <= vCompanyNr; vSelectingCompany++)
                    {
                        vCareer.SendKey(vKeyDown);
                        Thread.Sleep(200); //Since we can not check where we are we have to go slow
                    }

                    Thread.Sleep(200);

                    //Check if Last Company with the slider
                    if (IsVerticalScrollBar(vCareer))
                    {
                        if (IsVerticalScrollBarAtLowerEnd(vCareer))
                        {
                            vIsLastCompany = true;
                        }
                    }
                    else
                    {
                        vIsLastCompany = true;
                    }

                    //Now go into the single company screen
                    vCareer.SendKey(vKeySpace);
                    Thread.Sleep(1000);

                    string vStatusPrefix = "Comp " + vCompanyNr.ToString() + " ";
                    ExecutePlaneMaintenance(vCareer, vStatusPrefix);
                    bool vDone = false;
                    lock (sLock)
                    {
                        if (string.Equals(sStatus, "Done"))
                        {
                            vDone = true;
                        }
                    }
                    if (vDone)
                    {
                        if (vIsLastCompany)
                        {
                            ResetCompanyNr();
                            SetProgressLabel("All Done");
                        }
                        else
                        {
                            SetProgressLabel("Comp " + vCompanyNr.ToString() + " Done");
                            IncrementCompanyNr();
                        }
                    }
                    if (!vDone)
                    {

                        //Automatic unstuck

                        //try to ESC to the All Company Screen
                        //It usually stucks when opening the SubMenue of a Plane
                        //Then the ESC key doesn't work it shoul dhowever be recoverable with the Up key
                        if (!IsInAllCompanyScreen(vCareer))
                        {
                            vCareer.SendKey(vKeyUp);
                            Thread.Sleep(200);
                        }
                        if (!IsInAllCompanyScreen(vCareer))
                        {
                            vCareer.SendKey(vKeyEscape);
                            Thread.Sleep(200);
                        }
                        if (!IsInAllCompanyScreen(vCareer))
                        {
                            vCareer.SendKey(vKeyEscape);
                            Thread.Sleep(200);
                        }
                        if (!IsInAllCompanyScreen(vCareer))
                        {
                            vCareer.SendKey(vKeyEscape);
                            Thread.Sleep(200);
                        }
                        if (!IsInAllCompanyScreen(vCareer))
                        {
                            vCareer.SendKey(vKeyEscape);
                            Thread.Sleep(200);
                        }
                        if (!IsInAllCompanyScreen(vCareer))
                        {
                            //Give up
                            break;
                        }

                        //IF we are stuck at the very same point it is time to give up
                        if ((vLastFailedCompanyNr == GetCompanyNr()) &&
                            (vLastFailedPlaneNr == GetPlaneNr()))
                        {
                            break;
                        }
                        vLastFailedCompanyNr = GetCompanyNr();
                        vLastFailedPlaneNr = GetPlaneNr();
                    }
                    if (!vIsLastCompany)
                    {
                        Thread.Sleep(200);
                        vCareer.SendKey(vKeyUp);
                        Thread.Sleep(200);
                        vCareer.SendKey(vKeyUp);
                        Thread.Sleep(200);
                        vCareer.SendKey(vKeyLeft);
                        Thread.Sleep(200);
                    }
                }
            }
            finally
            {
                lock (sLock)
                {
                    sStopRequested = false;
                    sIsRunning = false;
                }
            }
        }

        public static void ExecutePlaneMaintenance(CareerNamespace.CareerAutomation vCareer, string iStatusPrefix)
        {
            //Keys
            string vKeyEscape = "{ESC}";
            string vKeyLeft = "{LEFT}";
            string vKeyRight = "{RIGHT}";
            string vKeyUp = "{UP}";
            string vKeyDown = "{DOWN}";
            string vKeySpace = " ";
            //string vKeyEnter = "{ENTER}";

            String vStringResult = String.Empty;


            //vCareer.Focus();    
            //vCareer.Screenshot();
            if (!IsInCompanyScreen(vCareer))
            {
                SetStatus(iStatusPrefix + " Not in Company Screen.");
                return;
            }



            //Do we have at least One Aircraft in this Company?
            if (!IsAtLeastOneAircraft(vCareer))
            {
                return;
            }

            //Do we have a Scorllbar
            bool vScrollBarExist = IsHorizontalScrollBar(vCareer);



            //Now let's try to go and select the firts Airraft
            if (vScrollBarExist)
            {
                //since we do not start mid list anymore we do not need to do 500 unstoppable attempts
                int vMaxTries = 5; //5 planes maximum, 3 max visible
                int vTryCount = 0;
                while ((vTryCount < vMaxTries) && !IsHorizontalScrollBarFarLeft(vCareer))
                {
                    vTryCount++;
                    vCareer.SendKey(vKeyLeft);
                    Thread.Sleep(10);
                    if (IsStopRequested())
                    {
                        SetStatus("Stopped");
                        return;
                    }
                }
                if (!IsHorizontalScrollBarFarLeft(vCareer))
                {
                    SetStatus(iStatusPrefix + " Can't scroll to the first Aircraft. MaxAttempts: " + vMaxTries.ToString());
                    return;
                }
            }

            //this is always required to activate the keys,
            //in case of Scrolls it moves also when the scroll is at the very and

            //At least one Left key is  Required to activate the key input
            //this will select the middle/third aircraft

            int vFixMaxTries = 5; //there should only be 3 without + 1 a scroll bar though
            int vFixTryCount = 0;
            while ((vFixTryCount < vFixMaxTries) && !IsFirstAircraftActive(vCareer))
            {
                vFixTryCount++;
                vCareer.SendKey(vKeyLeft);
                Thread.Sleep(100);
                if (IsStopRequested())
                {
                    SetStatus("Stopped");
                    return;
                }
            }


            if (!IsFirstAircraftActive(vCareer))
            {
                Thread.Sleep(1000);
            }
            if (!IsFirstAircraftActive(vCareer))
            {
                if (!IsBuyAircraftActive(vCareer))
                {
                    SetStatus(iStatusPrefix + " Can't find and select the first Aircraft. ");
                    return;
                }
                //Seems we ended on BuyAircraft
                vCareer.SendKey(vKeyRight);
                Thread.Sleep(1000);
                if (!IsFirstAircraftActive(vCareer))
                {
                    SetStatus(iStatusPrefix + " Can't find and select the first Aircraft. (BuyAircraft anomaly)");
                }
                return;
            }


            //We have found and selected the first Aircraft
            //figure out how many aircrafts we have if there is no scroll bar

            int vMaxPlaneCount = 1;
            if (!vScrollBarExist)
            {
                //the total max number here will be 3 meaning there are 3 plane visible without a scrolling bar
                vMaxPlaneCount += GetNonSScrollAdditionalPlaneCount(vCareer);
            }
            int vStartFromPlaneNr = GetPlaneNr();
            if (vStartFromPlaneNr > vMaxPlaneCount)
            {
                vMaxPlaneCount = vStartFromPlaneNr;
            }
            for (int vPlaneNr = vStartFromPlaneNr; vPlaneNr <= vMaxPlaneCount; vPlaneNr++)
            {
                if (IsStopRequested())
                {
                    SetStatus("Stopped");
                    return;
                }
                SetPlaneCounter(vPlaneNr);
                SetFullStatus("Running...");
                for (int vToTheRight = 1; vToTheRight < vPlaneNr; vToTheRight++)
                {
                    vCareer.SendKey(vKeyRight);
                    Thread.Sleep(50); //required
                    if (IsStopRequested())
                    {
                        SetStatus("Stopped");
                        return;
                    }
                }

                //Thread.Sleep(300);
                ////Not sure if this even makes sense because he will find an itermediate likely
                //if (!IsAircraftSelected(vCareer, vPlaneNr))
                //{
                //    SetStatus(iStatusPrefix + " Selecting " + vPlaneNr.ToString() + " failed");
                //    return;
                //}

                //unfortunatly the Scrollbar is covered as soon as we open the SubMenu..
                //but we might not be there ..in that case it might never stop and plane count is every increasing
                //Therefore we really have to make sure witha  sleep
                //Thread.Sleep(300);
                //if (vScrollBarExist)
                //{
                //    //Wait till Nth plane is selected
                //    if (!IsHorizontalScrollBarFarLRight(vCareer))
                //    {
                //        //Add one plane to the for loop
                //        vMaxPlaneCount++;
                //    }
                //}

                //Open SubMenu
                Thread.Sleep(300); //seems required
                vCareer.SendKey(vKeySpace);
                Thread.Sleep(100);
                bool vIsLastAircraft = false;
                if (!IsAircraftSubMenuOpenedAndActive(vCareer, vPlaneNr, out vIsLastAircraft))
                {
                    SetStatus(iStatusPrefix + " Opening Submenu " + vPlaneNr.ToString() + " failed");
                    return;
                }

                if (vScrollBarExist)
                {
                    if (!vIsLastAircraft)
                    {
                        //Add one plane to the for loop
                        vMaxPlaneCount++;
                    }
                }

                //Enter Maintenance
                vCareer.SendKey(vKeySpace);
                if (!IsInMaintenanceScreen(vCareer))
                {
                    SetStatus(iStatusPrefix + " Not in Maintenance Screen");
                    return;
                }
                Thread.Sleep(300); //seems required

                for (int vRepeatCheck = 1; vRepeatCheck <= 3; vRepeatCheck++)
                {
                    if (IsWashRequired(vCareer) || IsWashSelected(vCareer))
                    {
                        vCareer.SendKey(vKeyLeft);
                        vCareer.SendKey(vKeyUp);
                        vCareer.SendKey(vKeyDown);
                        Thread.Sleep(100);
                        bool vExecute = true;
                        if (!IsWashSelectedWithWait(vCareer))
                        {
                            //We can have a wrong required detection they screen update is sometimes too slow
                            //and it seems to init with active
                            if (!IsWashRequired(vCareer))
                            {
                                vExecute = false;
                            }
                            SetStatus(iStatusPrefix + " Wash Selection Failed");
                            return;
                        }
                        if (vExecute)
                        {
                            Thread.Sleep(100);
                            vCareer.SendKey(vKeySpace);
                            Thread.Sleep(100);
                            if (!IsInSplashScreen(vCareer))
                            {
                                SetStatus(iStatusPrefix + " No confirm Dialog for Wash");
                                return;
                            }
                            Thread.Sleep(200);
                            vCareer.SendKey(vKeySpace);
                            Thread.Sleep(200);
                        }
                    }
                    if (!IsInMaintenanceScreen(vCareer))
                    {
                        SetStatus(iStatusPrefix + " Not in Maintenance Screen after Wash");
                        return;
                    }

                    if (IsCheckUpRequired(vCareer) || IsCheckUpSelected(vCareer)) //It will be selected if we enter the menu so required failes that detection
                    {
                        vCareer.SendKey(vKeyLeft);
                        vCareer.SendKey(vKeyUp);
                        Thread.Sleep(100);
                        bool vExecute = true;
                        if (!IsCheckUpSelectedWithWait(vCareer))
                        {   //instead selection it might be a false  detection
                            if (!IsCheckUpRequired(vCareer))
                            {
                                vExecute = false;
                            }
                            SetStatus(iStatusPrefix + " CheckUp Selection Failed");
                            return;
                        }
                        if (vExecute)
                        {
                            Thread.Sleep(100);
                            vCareer.SendKey(vKeySpace);
                            Thread.Sleep(100);
                            if (!IsInSplashScreen(vCareer))
                            {
                                SetStatus(iStatusPrefix + " No confirm Dialog for CheckUp");
                                return;
                            }
                            Thread.Sleep(200);
                            vCareer.SendKey(vKeySpace);
                            Thread.Sleep(200);
                        }
                    }
                    if (!IsInMaintenanceScreen(vCareer))
                    {
                        SetStatus(iStatusPrefix + " Not in Maintenance Screen after CheckUp");
                        return;
                    }

                    if (IsDelegateRequired(vCareer) || IsDelegateSelected(vCareer))
                    {
                        vCareer.SendKey(vKeyLeft);
                        vCareer.SendKey(vKeyUp);
                        vCareer.SendKey(vKeyRight);
                        Thread.Sleep(100);
                        bool vExecute = true;
                        if (!IsDelegateSelectedWithWait(vCareer))
                        {
                            //instead selection it might be a fals DelegateRequired detection
                            if (!IsDelegateRequired(vCareer))
                            {
                                vExecute = false;
                            }
                            SetStatus(iStatusPrefix + " Delegate Selection Failed");
                            return;
                        }
                        if (vExecute)
                        {
                            Thread.Sleep(100);
                            vCareer.SendKey(vKeySpace);
                            Thread.Sleep(100);
                            if (!IsInSplashScreen(vCareer))
                            {
                                SetStatus(iStatusPrefix + " No confirm Dialog for Delegate");
                                return;
                            }
                            Thread.Sleep(200);
                            vCareer.SendKey(vKeySpace);
                            Thread.Sleep(200);
                        }
                    }
                    if (!IsInMaintenanceScreen(vCareer))
                    {
                        SetStatus(iStatusPrefix + " Not in Maintenance Screen after Delegate");
                        return;
                    }
                }


                //Get Out
                vCareer.SendKey(vKeyEscape);
                if (!IsInCompanyScreen(vCareer))
                {
                    SetStatus(iStatusPrefix + " Not in Company Screen.2");
                    return;
                }
            }

            vCareer.SendKey(vKeyEscape);

            SetStatus("Done");

            return;
        }


        private static void ReadScreenPixel(CareerNamespace.CareerAutomation iCareer, CareerPixelPos iPos, out CareerPixelColor oColor, string iSaveName = null)
        {
            CareerPixelPos vScreenScaledPos = TransfromPixelPos(iPos);

            int cRadius = 10;
            Bitmap bmpScreenshot = iCareer.PartialScreenshot(vScreenScaledPos.mPosX - cRadius, vScreenScaledPos.mPosY - cRadius, 2 * cRadius + 1, 2 * cRadius + 1);


            int vPixelsInX = bmpScreenshot.Width;
            int vPixelsInY = bmpScreenshot.Height;
            UInt32[,] vAreaBitmapArray = new UInt32[vPixelsInY, vPixelsInX];

            GCHandle vGCHandle = GCHandle.Alloc(vAreaBitmapArray, GCHandleType.Pinned);
            IntPtr vPointer = Marshal.UnsafeAddrOfPinnedArrayElement(vAreaBitmapArray, 0);

            Bitmap vAreaBitmap = new Bitmap(vPixelsInX, vPixelsInY, vPixelsInX << 2, System.Drawing.Imaging.PixelFormat.Format32bppArgb, vPointer);

            Graphics vAreaGraphics = Graphics.FromImage(vAreaBitmap);

            vAreaGraphics.DrawImage(bmpScreenshot, new Point(0, 0));

            if (!string.IsNullOrEmpty(iSaveName))
            {
                vAreaBitmap.Save(iSaveName + ".bmp");
            }

            UInt32 vValue = vAreaBitmapArray[cRadius, cRadius];
            int vRed = (Int32)((vValue & 0x00FF0000) >> 16);
            int vGreen = (Int32)((vValue & 0x0000FF00) >> 8);
            int vBlue = (Int32)(vValue & 0x000000FF);

            oColor = new CareerPixelColor(vRed, vGreen, vBlue);
        }

        private static CareerPixelPos TransfromPixelPos(CareerPixelPos iPos)
        {
            double vRelativeToReferenceScreenCenterPosX = (double)(iPos.mPosX) - 0.5 * (double)(cReferenceScreenWidth);
            double vRelativeToReferenceScreenCenterPosY = (double)(iPos.mPosY) - 0.5 * (double)(cReferenceScreenHeight);
            double vScaledAndRelativeToUserScreenCenterPosX = sUIScaleing * vRelativeToReferenceScreenCenterPosX;
            double vScaledAndRelativeToUserScreenCenterPosY = sUIScaleing * vRelativeToReferenceScreenCenterPosY;
            int vTransofrmedPixelPosX = (int)Math.Round(sScreenCenterX + vScaledAndRelativeToUserScreenCenterPosX);
            int vTransofrmedPixelPosY = (int)Math.Round(sScreenCenterY + vScaledAndRelativeToUserScreenCenterPosY);
            CareerPixelPos vTransformedPixelPos = new CareerPixelPos(vTransofrmedPixelPosX, vTransofrmedPixelPosY);
            return vTransformedPixelPos;
        }

        private static bool IsColorWithinExpectedColor(int iEpsilon, CareerPixelColor iColor1, CareerPixelColor iColor2)
        {
            if (!(Math.Abs(iColor1.mRed - iColor2.mRed) <= iEpsilon))
            {
                return false;
            }
            if (!(Math.Abs(iColor1.mGreen - iColor2.mGreen) <= iEpsilon))
            {
                return false;
            }
            if (!(Math.Abs(iColor1.mBlue - iColor2.mBlue) <= iEpsilon))
            {
                return false;
            }
            return true;
        }

        private static bool IsInSplashScreen(CareerNamespace.CareerAutomation iCareer)
        {
            bool vScreenFound = false;
            for (int vAttempt = 1; vAttempt < 30; vAttempt++)
            {
                vScreenFound = true;

                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cCompanyIdentifySplashScreen.mPos, out vColor1);
                int vColorEpsilon = 20;
                if (!IsColorWithinExpectedColor(vColorEpsilon, cCompanyIdentifySplashScreen.mColor, vColor1))
                {
                    vScreenFound = false;
                }

                if (vScreenFound)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            return vScreenFound;
        }

        private static bool IsInAllCompanyScreen(CareerNamespace.CareerAutomation iCareer)
        {
            bool vScreenFound = false;
            for (int vAttempt = 1; vAttempt < 10; vAttempt++)
            {
                vScreenFound = true;

                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cAllCompanyIdentifyActiveFirstBottomLeft.mPos, out vColor1); //"AllCompFirst"
                int vColorEpsilon1 = 20;
                bool vFound1 = IsColorWithinExpectedColor(vColorEpsilon1, cAllCompanyIdentifyActiveFirstBottomLeft.mColor, vColor1);

                CareerPixelColor vColor2;
                ReadScreenPixel(iCareer, cAllCompanyIdentifyInactiveFirstBottomLeft.mPos, out vColor2);
                int vColorEpsilon2 = 20;
                bool vFound2 = IsColorWithinExpectedColor(vColorEpsilon2, cAllCompanyIdentifyInactiveFirstBottomLeft.mColor, vColor2);

                CareerPixelColor vColor3;
                ReadScreenPixel(iCareer, cAllCompanyIdentifySelectedFirstBottomLeft.mPos, out vColor3);
                int vColorEpsilon3 = 52;
                bool vFound3 = IsColorWithinExpectedColor(vColorEpsilon3, cAllCompanyIdentifySelectedFirstBottomLeft.mColor, vColor3);

                if (!(vFound1 || vFound2 || vFound3))
                {
                    vScreenFound = false;
                }

                if (vScreenFound)
                {
                    ReadScreenPixel(iCareer, cAllCompanyIdentifyActiveSecondBottomLeft.mPos, out vColor1); //"AllCompSecond"
                    vFound1 = IsColorWithinExpectedColor(vColorEpsilon1, cAllCompanyIdentifyActiveSecondBottomLeft.mColor, vColor1);

                    ReadScreenPixel(iCareer, cAllCompanyIdentifyInactiveSecondBottomLeft.mPos, out vColor2);
                    vFound2 = IsColorWithinExpectedColor(vColorEpsilon2, cAllCompanyIdentifyInactiveSecondBottomLeft.mColor, vColor2);

                    ReadScreenPixel(iCareer, cAllCompanyIdentifySelectedSecondBottomLeft.mPos, out vColor3);
                    vFound3 = IsColorWithinExpectedColor(vColorEpsilon3, cAllCompanyIdentifySelectedSecondBottomLeft.mColor, vColor3);

                    if (!(vFound1 || vFound2 || vFound3))
                    {
                        vScreenFound = false;
                    }
                }

                if (vScreenFound)
                {
                    ReadScreenPixel(iCareer, cAllCompanyIdentifyActiveThirdBottomLeft.mPos, out vColor1); //"AllCompThird"
                    vFound1 = IsColorWithinExpectedColor(vColorEpsilon1, cAllCompanyIdentifyActiveThirdBottomLeft.mColor, vColor1);

                    ReadScreenPixel(iCareer, cAllCompanyIdentifyInactiveThirdBottomLeft.mPos, out vColor2);
                    vFound2 = IsColorWithinExpectedColor(vColorEpsilon2, cAllCompanyIdentifyInactiveThirdBottomLeft.mColor, vColor2);

                    ReadScreenPixel(iCareer, cAllCompanyIdentifySelectedThirdBottomLeft.mPos, out vColor3);
                    vFound3 = IsColorWithinExpectedColor(vColorEpsilon3, cAllCompanyIdentifySelectedThirdBottomLeft.mColor, vColor3);

                    if (!(vFound1 || vFound2 || vFound3))
                    {
                        vScreenFound = false;
                    }
                }


                if (vScreenFound)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            return vScreenFound;
        }

        private static bool IsInAllCompanyScreenFirstWhiteSelected(CareerNamespace.CareerAutomation iCareer)
        {
            bool vScreenFound = false;
            for (int vAttempt = 1; vAttempt < 10; vAttempt++)
            {
                vScreenFound = true;

                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cAllCompanyIdentifySelectedFirstBottomLeft.mPos, out vColor1);
                int vWhiteEpsilon = 52;
                bool vFound1 = IsColorWithinExpectedColor(vWhiteEpsilon, cAllCompanyIdentifySelectedFirstBottomLeft.mColor, vColor1);

                if (!vFound1)
                {
                    vScreenFound = false;
                }

                if (vScreenFound)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            return vScreenFound;
        }

        private static bool IsInCompanyScreen(CareerNamespace.CareerAutomation iCareer)
        {
            bool vScreenFound = false;
            for (int vAttempt = 1; vAttempt < 30; vAttempt++)
            {
                vScreenFound = true;

                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cCompanyIdentifyActive.mPos, out vColor1);
                int vColorEpsilon = 20;
                if (!IsColorWithinExpectedColor(vColorEpsilon, cCompanyIdentifyActive.mColor, vColor1))
                {
                    vScreenFound = false;
                }

                CareerPixelColor vColor2;
                ReadScreenPixel(iCareer, cMaintenanceIdentifyActive.mPos, out vColor2);
                if (IsColorWithinExpectedColor(vColorEpsilon, cMaintenanceIdentifyActive.mColor, vColor2))
                {
                    vScreenFound = false;
                }

                if (vScreenFound)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            return vScreenFound;
        }


        private static bool IsInMaintenanceScreen(CareerNamespace.CareerAutomation iCareer)
        {
            bool vScreenFound = false;
            for (int vAttempt = 1; vAttempt < 60; vAttempt++)
            {
                vScreenFound = true;

                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cCompanyIdentifyActive.mPos, out vColor1);
                int vColorEpsilon = 20;
                if (!IsColorWithinExpectedColor(vColorEpsilon, cCompanyIdentifyActive.mColor, vColor1))
                {
                    vScreenFound = false;
                }

                CareerPixelColor vColor2;
                ReadScreenPixel(iCareer, cMaintenanceIdentifyActive.mPos, out vColor2);
                if (!IsColorWithinExpectedColor(vColorEpsilon, cMaintenanceIdentifyActive.mColor, vColor2))
                {
                    vScreenFound = false;
                }

                if (vScreenFound)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            return vScreenFound;
        }

        private static bool IsVerticalScrollBar(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cVerticalBarUpperEndInnerInactive.mPos, out vColor1);
            int vColorEpsilon1 = 20;
            bool vFound1 = IsColorWithinExpectedColor(vColorEpsilon1, cVerticalBarUpperEndInnerInactive.mColor, vColor1);

            CareerPixelColor vColor2;
            ReadScreenPixel(iCareer, cVerticalBarUpperEndInnerActive.mPos, out vColor2);
            int vColorEpsilon2 = 20;
            bool vFound2 = IsColorWithinExpectedColor(vColorEpsilon2, cVerticalBarUpperEndInnerActive.mColor, vColor2);

            CareerPixelColor vColor3;
            ReadScreenPixel(iCareer, cVerticalBarLowerEndInnerInactive.mPos, out vColor3);
            int vColorEpsilon3 = 20;
            bool vFound3 = IsColorWithinExpectedColor(vColorEpsilon3, cVerticalBarLowerEndInnerInactive.mColor, vColor3);

            CareerPixelColor vColor4;
            ReadScreenPixel(iCareer, cVerticalBarLowerEndInnerActive.mPos, out vColor4);
            int vColorEpsilon4 = 20;
            bool vFound4 = IsColorWithinExpectedColor(vColorEpsilon4, cVerticalBarLowerEndInnerActive.mColor, vColor4);

            if ((vFound1 || vFound2) && (vFound3 || vFound4))
            {
                return true;
            }

            return false;
        }

        private static bool IsVerticalScrollBarAtLowerEnd(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor4;
            ReadScreenPixel(iCareer, cVerticalBarLowerEndInnerActive.mPos, out vColor4);
            int vColorEpsilon4 = 20;
            bool vFound4 = IsColorWithinExpectedColor(vColorEpsilon4, cVerticalBarLowerEndInnerActive.mColor, vColor4);

            if (vFound4)
            {
                return true;
            }

            return false;
        }

        private static bool IsHorizontalScrollBar(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cHorizontalBarRightEndInnerInactive.mPos, out vColor1);

            int vColorEpsilon = 15; //20 doesn't work in FullHD 
            if (IsColorWithinExpectedColor(vColorEpsilon, cHorizontalBarRightEndInnerInactive.mColor, vColor1))
            {
                return true;
            }

            CareerPixelColor vColor2;
            ReadScreenPixel(iCareer, cHorizontalBarRightEndInnerActive.mPos, out vColor2);
            if (IsColorWithinExpectedColor(vColorEpsilon, cHorizontalBarRightEndInnerActive.mColor, vColor2))
            {
                return true;
            }

            return false;
        }
        private static bool IsHorizontalScrollBarFarLeft(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cHorizontalBarLeftEndInnerActive.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cHorizontalBarLeftEndInnerActive.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static bool IsHorizontalScrollBarFarLRight(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cHorizontalBarRightEndInnerActive.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cHorizontalBarRightEndInnerActive.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static bool IsAtLeastOneAircraft(CareerNamespace.CareerAutomation iCareer)
        {
            if (IsHorizontalScrollBar(iCareer))
            {
                return true;
            }
            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cFirstAricraftExistAndInactie.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cFirstAricraftExistAndInactie.mColor, vColor1))
            {
                return true;
            }

            int vColorEpsilon2 = 52;
            CareerPixelColor vColor2;
            ReadScreenPixel(iCareer, cFirstAircraftExistAndActive.mPos, out vColor2);
            if (IsColorWithinExpectedColor(vColorEpsilon2, cFirstAircraftExistAndActive.mColor, vColor2))
            {
                return true;
            }

            return false;
        }

        private static bool IsFirstAircraftActive(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cFirstAircraftExistAndActive.mPos, out vColor1);

            int vColorEpsilon = 52;
            if (IsColorWithinExpectedColor(vColorEpsilon, cFirstAircraftExistAndActive.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static bool IsBuyAircraftActive(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cBuyAricraftActive.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cBuyAricraftActive.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static int GetNonSScrollAdditionalPlaneCount(CareerNamespace.CareerAutomation iCareer)
        {

            int vAdditionalPlaneCount = 0;

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cSecondAricraftExistAndInactie.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cSecondAricraftExistAndInactie.mColor, vColor1))
            {
                vAdditionalPlaneCount++;
            }

            CareerPixelColor vColor2;
            ReadScreenPixel(iCareer, cThirdAricraftExistAndInactie.mPos, out vColor2);
            if (IsColorWithinExpectedColor(vColorEpsilon, cSecondAricraftExistAndInactie.mColor, vColor2))
            {
                vAdditionalPlaneCount++;
            }

            return vAdditionalPlaneCount;
        }

        private static bool IsAircraftSelected(CareerNamespace.CareerAutomation iCareer, int iPlaneNr)
        {
            for (int vAttempts = 1; vAttempts <= 10; vAttempts++)
            {
                if (iPlaneNr == 1)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cFirstAircraftExistAndActive.mPos, out vColor1);

                    int vColorEpsilon = 52;
                    if (IsColorWithinExpectedColor(vColorEpsilon, cFirstAircraftExistAndActive.mColor, vColor1))
                    {
                        return true;
                    }
                }
                if (iPlaneNr == 2)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cSecondAricraftExistAndActive.mPos, out vColor1);

                    int vColorEpsilon = 52;
                    if (IsColorWithinExpectedColor(vColorEpsilon, cSecondAricraftExistAndActive.mColor, vColor1))
                    {
                        return true;
                    }
                }
                if (iPlaneNr == 3)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cThirdAricraftExistAndActive.mPos, out vColor1);

                    int vColorEpsilon = 52;
                    if (IsColorWithinExpectedColor(vColorEpsilon, cThirdAricraftExistAndActive.mColor, vColor1))
                    {
                        return true;
                    }
                }
                if (iPlaneNr > 3)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cNthAricraftExistAndActive.mPos, out vColor1);

                    int vColorEpsilon = 52;
                    if (IsColorWithinExpectedColor(vColorEpsilon, cNthAricraftExistAndActive.mColor, vColor1))
                    {
                        return true;
                    }
                }
                Thread.Sleep(200);
            }

            return false;
        }

        private static bool IsAircraftSubMenuOpenedAndActive(CareerNamespace.CareerAutomation iCareer, int iPlaneNr, out bool oIsLastAircraft)
        {
            oIsLastAircraft = false;
            for (int vAttempts = 1; vAttempts <= 40; vAttempts++)
            {
                if (iPlaneNr == 1)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cFirstAircraftOpenSubMenuActive.mPos, out vColor1); //"SubMenuActive"
                    CareerPixelColor vColor2;
                    ReadScreenPixel(iCareer, cFirstAircraftOpenSubMenuBottom.mPos, out vColor2);

                    int vColorEpsilon1 = 52;
                    int vColorEpsilon2 = 20;
                    if ((IsColorWithinExpectedColor(vColorEpsilon1, cFirstAircraftOpenSubMenuActive.mColor, vColor1)) &&
                        (IsColorWithinExpectedColor(vColorEpsilon2, cFirstAircraftOpenSubMenuBottom.mColor, vColor2)))
                    {
                        return true;
                    }
                }
                if (iPlaneNr == 2)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cSecondAircraftOpenSubMenuActive.mPos, out vColor1);
                    CareerPixelColor vColor2;
                    ReadScreenPixel(iCareer, cSecondAircraftOpenSubMenuBottom.mPos, out vColor2);

                    int vColorEpsilon1 = 52;
                    int vColorEpsilon2 = 20;
                    if ((IsColorWithinExpectedColor(vColorEpsilon1, cSecondAircraftOpenSubMenuActive.mColor, vColor1)) &&
                        (IsColorWithinExpectedColor(vColorEpsilon2, cSecondAircraftOpenSubMenuBottom.mColor, vColor2)))
                    {
                        return true;
                    }
                }
                if (iPlaneNr == 3)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cThirdAircraftOpenSubMenuActive.mPos, out vColor1);
                    CareerPixelColor vColor2;
                    ReadScreenPixel(iCareer, cThirdAircraftOpenSubMenuBottom.mPos, out vColor2);

                    int vColorEpsilon1 = 52;
                    int vColorEpsilon2 = 20;
                    if ((IsColorWithinExpectedColor(vColorEpsilon1, cThirdAircraftOpenSubMenuActive.mColor, vColor1)) &&
                        (IsColorWithinExpectedColor(vColorEpsilon2, cThirdAircraftOpenSubMenuBottom.mColor, vColor2)))
                    {
                        return true;
                    }
                }
                if (iPlaneNr > 3)
                {
                    CareerPixelColor vColor1;
                    ReadScreenPixel(iCareer, cLastAircraftOpenSubMenuActive.mPos, out vColor1);
                    CareerPixelColor vColor2;
                    ReadScreenPixel(iCareer, cLastAircraftOpenSubMenuBottom.mPos, out vColor2);

                    int vColorEpsilon1 = 52;
                    int vColorEpsilon2 = 20;
                    if ((IsColorWithinExpectedColor(vColorEpsilon1, cLastAircraftOpenSubMenuActive.mColor, vColor1)) &&
                        (IsColorWithinExpectedColor(vColorEpsilon2, cLastAircraftOpenSubMenuBottom.mColor, vColor2)))
                    {
                        oIsLastAircraft = true;
                        return true;
                    }


                    ReadScreenPixel(iCareer, cNthAircraftOpenSubMenuActive.mPos, out vColor1);
                    ReadScreenPixel(iCareer, cNthAircraftOpenSubMenuBottom.mPos, out vColor2);

                    if ((IsColorWithinExpectedColor(vColorEpsilon1, cNthAircraftOpenSubMenuActive.mColor, vColor1)) &&
                        (IsColorWithinExpectedColor(vColorEpsilon2, cNthAircraftOpenSubMenuBottom.mColor, vColor2)))
                    {
                        return true;
                    }
                }
                Thread.Sleep(100);
            }

            return false;
        }

        private static bool IsWashRequired(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cWashActive.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cWashActive.mColor, vColor1))
            {
                return true;
            }

            return false;
        }
        private static bool IsCheckUpRequired(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cCheckUpActive.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cCheckUpActive.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static bool IsDelegateRequired(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cDelegateActive.mPos, out vColor1);

            int vColorEpsilon = 20;
            if (IsColorWithinExpectedColor(vColorEpsilon, cDelegateActive.mColor, vColor1))
            {
                return true;
            }

            return false;
        }


        private static bool IsWashSelected(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cWashSelected.mPos, out vColor1);

            int vColorEpsilon = 52;
            if (IsColorWithinExpectedColor(vColorEpsilon, cWashSelected.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static bool IsWashSelectedWithWait(CareerNamespace.CareerAutomation iCareer)
        {
            for (int vAttempts = 1; vAttempts <= 20; vAttempts++)
            {
                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cWashSelected.mPos, out vColor1);

                int vColorEpsilon = 52;
                if (IsColorWithinExpectedColor(vColorEpsilon, cWashSelected.mColor, vColor1))
                {
                    return true;
                }
                Thread.Sleep(100);
            }

            return false;
        }

        private static bool IsCheckUpSelected(CareerNamespace.CareerAutomation iCareer)
        {
            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cCheckUpSelected.mPos, out vColor1);

            int vColorEpsilon = 52;
            if (IsColorWithinExpectedColor(vColorEpsilon, cCheckUpSelected.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static bool IsCheckUpSelectedWithWait(CareerNamespace.CareerAutomation iCareer)
        {
            for (int vAttempts = 1; vAttempts <= 20; vAttempts++)
            {
                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cCheckUpSelected.mPos, out vColor1);

                int vColorEpsilon = 52;
                if (IsColorWithinExpectedColor(vColorEpsilon, cCheckUpSelected.mColor, vColor1))
                {
                    return true;
                }
                Thread.Sleep(100);
            }

            return false;
        }



        private static bool IsDelegateSelected(CareerNamespace.CareerAutomation iCareer)
        {

            CareerPixelColor vColor1;
            ReadScreenPixel(iCareer, cDelegateSelected.mPos, out vColor1);

            int vColorEpsilon = 52;
            if (IsColorWithinExpectedColor(vColorEpsilon, cDelegateSelected.mColor, vColor1))
            {
                return true;
            }

            return false;
        }

        private static bool IsDelegateSelectedWithWait(CareerNamespace.CareerAutomation iCareer)
        {
            for (int vAttempts = 1; vAttempts <= 20; vAttempts++)
            {
                CareerPixelColor vColor1;
                ReadScreenPixel(iCareer, cDelegateSelected.mPos, out vColor1);

                int vColorEpsilon = 52;
                if (IsColorWithinExpectedColor(vColorEpsilon, cDelegateSelected.mColor, vColor1))
                {
                    return true;
                }
                Thread.Sleep(100);
            }

            return false;
        }
    }
}
