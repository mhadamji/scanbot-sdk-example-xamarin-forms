﻿using System;
using System.IO;
using Foundation;
using ScanbotSDK.Xamarin.Forms;
using UIKit;

namespace scanbotsdkexamplexamarinforms.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        // TODO Add the Scanbot SDK license key here.
        // Please note: The Scanbot SDK will run without a license key for one minute per session!
        // After the trial period is over all Scanbot SDK functions as well as the UI components will stop working
        // or may be terminated. You can get an unrestricted "no-strings-attached" 30 day trial license key for free.
        // Please submit the trial license form (https://scanbot.io/sdk/trial.html) on our website by using
        // the app identifier "io.scanbot.example.sdk.xamarin.forms" of this example app.
        const string LICENSE_KEY = null;


        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Console.WriteLine("Scanbot SDK Example: Initializing Scanbot SDK...");

            // Initialization with a custom "StorageBaseDirectory" for demo purposes - see comments below.
            SBSDKInitializer.Initialize(app, LICENSE_KEY, new SBSDKConfiguration { EnableLogging = true, StorageBaseDirectory = GetDemoStorageBaseDirectory() });

            // Alternative initialization with the default "StorageBaseDirectory".
            //SBSDKInitializer.Initialize(app, LICENSE_KEY, new SBSDKConfiguration { EnableLogging = true });

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        string GetDemoStorageBaseDirectory()
        {
            // For demo purposes we use a sub-folder in the Documents folder in the Data Container of this App, since the contents can be shared via iTunes.
            // For more detais about the iOS file system see:
            // - https://developer.apple.com/library/archive/documentation/FileManagement/Conceptual/FileSystemProgrammingGuide/FileSystemOverview/FileSystemOverview.html
            // - https://docs.microsoft.com/en-us/xamarin/ios/app-fundamentals/file-system
            // - https://docs.microsoft.com/en-us/dotnet/api/system.environment.specialfolder

            var customDocumentsFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "my-custom-storage");
            Directory.CreateDirectory(customDocumentsFolder);
            return customDocumentsFolder;
        }
    }
}
