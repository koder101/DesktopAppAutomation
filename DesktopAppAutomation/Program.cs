/******************************************************************
 * Author   : Zeeshaan Ali
 * Email    : Zeeshaanbond@yahoo.com
 * 
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE.md', which is part of this source code package.
 ******************************************************************/

namespace DesktopAppAutomation
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Text.RegularExpressions;
    using System.Windows.Automation;
    using Winium.Cruciatus.Core;

    public class Program
    {
        public static void Main(string[] args)
        {
            int index = -1;
            var actions = ConfigurationManager.GetSection("ActionSequence/Actions") as NameValueCollection;
            ByProperty winFinder = null;
            Winium.Cruciatus.Elements.CruciatusElement win = null;
            bool fault = false;
            foreach (var action in actions.AllKeys)
            {
                if (fault)
                    break;      // exit out of the loop in case of fault.

                if (action.Contains("ExecutablePath"))
                {
                    try
                    {
                        string appPath = actions[action];
                        var cm = new Winium.Cruciatus.Application(appPath);
                        cm.Start();                        
                        Console.WriteLine("\nExecutable Started : " + actions[action]);
                    }
                    catch (Exception ex)
                    {
                        fault = true;
                        Console.WriteLine("\nExecutable could not be started : " + actions[action]);
                        Console.WriteLine("\n\n" + ex.Message + "\n");
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (action.Contains("WinFinder"))
                {
                    try
                    {
                        winFinder = By.Name(actions[action]).AndType(ControlType.Window);
                        win = Winium.Cruciatus.CruciatusFactory.Root.FindElement(winFinder);
                        Console.WriteLine("\nWindow Found : " + actions[action]);
                    }     
                    catch (Exception ex)
                    {
                        fault = true;
                        Console.WriteLine("\nWindow not Found : " + actions[action]);
                        Console.WriteLine("\n\n" + ex.Message + "\n");
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (action.Contains("FindElementByUid"))
                {
                    try
                    { 
                        var element = win.FindElementByUid(actions[action]);
                        Console.WriteLine("\nFindElementByUid found : " + actions[action]);
                        element.Click();
                    }
                    catch (Exception ex)
                    {
                        fault = true;
                        Console.WriteLine("\nFindElementByUid not Found : " + actions[action]);
                        Console.WriteLine("\n\n" + ex.Message + "\n");
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (action.Contains("FindElementByName"))
                {
                    try
                    {
                        var element = win.FindElementByName(actions[action]);
                        Console.WriteLine("\nElementByName found : " + actions[action]);
                        element.Click();
                    }
                    catch (Exception ex)
                    {
                        fault = true;
                        Console.WriteLine("\nElementByName not Found : " + actions[action]);
                        Console.WriteLine("\n\n"+ex.Message + "\n");
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (action.Contains("Wait"))
                {
                    Console.WriteLine("\nWaiting for " + actions[action] + " seconds");
                    System.Threading.Thread.Sleep(Convert.ToInt32(actions[action]) * 1000);
                }

                if (action.Contains("SetFocus"))
                {
                    try
                    {
                        var element = win.FindElementByUid(actions[action]);
                        Console.WriteLine("\nSetFocus found : " + actions[action]);
                        element.SetFocus();
                    }
                    catch (Exception ex)
                    {
                        fault = true;
                        Console.WriteLine("\nSetFocus not Found : " + actions[action]);
                        Console.WriteLine("\n\n" + ex.Message + "\n");
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (action.Contains("SetFocusByName"))
                {
                    try
                    {
                        var element = win.FindElementByName(actions[action]);
                        Console.WriteLine("\nSetFocusByName found : " + actions[action]);
                        element.SetFocus();
                    }
                    catch (Exception ex)
                    {
                        fault = true;
                        Console.WriteLine("\nSetFocusByName not Found : " + actions[action]);
                        Console.WriteLine("\n\n" + ex.Message + "\n");
                        Console.WriteLine(ex.ToString());
                    }
                }
                if (action.Contains("SetText"))
                {
                    try
                    {                        
                        if (0 != args.Length)
                        {
                            var element = win.FindElementByUid(actions[action]);
                            Console.WriteLine("\nSetText found : " + actions[action]);
                            element.SetText(args[++index]);
                        }
                        else
                        {
                            var controlAndTextArray = Regex.Split(actions[action], @";#");
                            if (controlAndTextArray.Length > 1)
                            {
                                var element = win.FindElementByUid(controlAndTextArray[0]);
                                Console.WriteLine("\nSetText found : " + actions[action]);
                                    element.SetText(controlAndTextArray[1]);
                            }
                            else
                            {
                                var element = win.FindElementByUid(actions[action]);
                                Console.WriteLine("\nSetText found : " + actions[action]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        fault = true;
                        Console.WriteLine("\nSetText not Found : " + actions[action]);
                        Console.WriteLine("\n\n" + ex.Message + "\n");
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            if(fault)
                Console.WriteLine("\n\nSome fault has occured.");
            else
                Console.WriteLine("\n\nAutomation happened successfully.");
            Console.ReadLine();
        }
    }
}
