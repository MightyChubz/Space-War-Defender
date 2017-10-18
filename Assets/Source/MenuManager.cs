﻿using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;
using System.Collections;
using System;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public GameObject setName;
    public Text inputFieldText;

    // Start is called just before any of the Update methods is called the first time
    public void Start()
    {
        setName.SetActive(false);

        if (VariableManager.IsWindows)
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\SpaceWarDefender\\SaveData"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    "\\SpaceWarDefender\\SaveData");
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\SpaceWarDefender\\SaveData\\GraphicsSettings.xml"))
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("qualitySettings",
                    new XComment("DO NOT EDIT THIS FILE UNLESS ISSUES OCCUR IN THE SETTINGS OF THE GAME!"),
                    new XComment("Setting for the graphics of the game."),
                    new XElement("quality",
                    new XElement("vsync", QualitySettings.vSyncCount),
                    new XElement("textureRes", QualitySettings.masterTextureLimit),
                    new XElement("anisotropicFiltering", 0),
                    new XElement("antiAliasing", QualitySettings.antiAliasing)),
                    new XComment("End of Class")));
                document.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    "\\SpaceWarDefender\\SaveData\\GraphicsSettings.xml");
            }
            else
            {
                XDocument document = XDocument.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    "\\SpaceWarDefender\\SaveData\\GraphicsSettings.xml");
                XElement element = document.Element("qualitySettings").Element("quality");

                QualitySettings.vSyncCount = Convert.ToInt32(element.Element("vsync").Value);
                QualitySettings.masterTextureLimit = Convert.ToInt32(element.Element("textureRes").Value);

                switch (Convert.ToInt32(element.Element("anisotropicFiltering").Value))
                {
                    case 0:
                        QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                        break;
                    case 1:
                        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                        break;
                    case 2:
                        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                        break;
                }

                QualitySettings.antiAliasing = Convert.ToInt32(element.Element("antiAliasing").Value);
            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                XDocument document = XDocument.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                       "\\SpaceWarDefender\\SaveData\\UserSettings.xml");
                XElement element = document.Element("userSettings").Element("profile");

                VariableManager.UserName = element.Element("name").Value;
                VariableManager.ScoreCapToggle = Convert.ToBoolean(element.Element("scoreCap").Value);

                switch (element.Element("name").Value)
                {
                    case "":
                        setName.SetActive(true);
                        break;
                }
            }
            else if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                setName.SetActive(true);
            }
        }
        else
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
            "\\Library\\SpaceWarDefender\\SaveData"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                    "\\Library\\SpaceWarDefender\\SaveData");
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                "\\Library\\SpaceWarDefender\\SaveData\\GraphicsSettings.xml"))
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("qualitySettings",
                    new XComment("DO NOT EDIT THIS FILE UNLESS ISSUES OCCUR IN THE SETTINGS OF THE GAME!"),
                    new XComment("Setting for the graphics of the game."),
                    new XElement("quality",
                    new XElement("vsync", QualitySettings.vSyncCount),
                    new XElement("textureRes", QualitySettings.masterTextureLimit),
                    new XElement("anisotropicFiltering", 0),
                    new XElement("antiAliasing", QualitySettings.antiAliasing)),
                    new XComment("End of Class")));
                document.Save(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                    "\\SpaceWarDefender\\SaveData\\GraphicsSettings.xml");
            }
            else
            {
                XDocument document = XDocument.Load(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                    "\\Library\\SpaceWarDefender\\SaveData\\GraphicsSettings.xml");
                XElement element = document.Element("qualitySettings").Element("quality");

                QualitySettings.vSyncCount = Convert.ToInt32(element.Element("vsync").Value);
                QualitySettings.masterTextureLimit = Convert.ToInt32(element.Element("textureRes").Value);

                switch (Convert.ToInt32(element.Element("anisotropicFiltering").Value))
                {
                    case 0:
                        QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
                        break;
                    case 1:
                        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
                        break;
                    case 2:
                        QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
                        break;
                }

                QualitySettings.antiAliasing = Convert.ToInt32(element.Element("antiAliasing").Value);
            }

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                "\\Library\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                XDocument document = XDocument.Load(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                       "\\Library\\SpaceWarDefender\\SaveData\\UserSettings.xml");
                XElement element = document.Element("userSettings").Element("profile");

                VariableManager.UserName = element.Element("name").Value;
                VariableManager.ScoreCapToggle = Convert.ToBoolean(element.Element("scoreCap").Value);

                switch (element.Element("name").Value)
                {
                    case "":
                        setName.SetActive(true);
                        break;
                }
            }
            else if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                "\\Library\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                setName.SetActive(true);
            }
        }
    }

    public void SetName()
    {
        VariableManager.UserName = inputFieldText.text;
        VariableManager.ScoreCapToggle = true;

        if (VariableManager.IsWindows)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            "\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("userSettings",
                    new XComment("DO NOT EDIT THIS FILE UNLESS ISSUES OCCUR IN THE SETTINGS OF THE GAME!"),
                    new XComment("Setting for the profile or user of the game."),
                    new XElement("profile",
                    new XElement("name", VariableManager.UserName),
                    new XElement("scoreCap", VariableManager.ScoreCapToggle)),
                    new XComment("End of Class")));
                document.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    "\\SpaceWarDefender\\SaveData\\UserSettings.xml");
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    "\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("userSettings",
                    new XComment("DO NOT EDIT THIS FILE UNLESS ISSUES OCCUR IN THE SETTINGS OF THE GAME!"),
                    new XComment("Setting for the profile or user of the game."),
                    new XElement("profile",
                    new XElement("name", VariableManager.UserName),
                    new XElement("scoreCap", VariableManager.ScoreCapToggle)),
                    new XComment("End of Class")));
                document.Save(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                    "\\SpaceWarDefender\\SaveData\\UserSettings.xml");
            }
        }
        else
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
            "\\Library\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("userSettings",
                    new XComment("DO NOT EDIT THIS FILE UNLESS ISSUES OCCUR IN THE SETTINGS OF THE GAME!"),
                    new XComment("Setting for the profile or user of the game."),
                    new XElement("profile",
                    new XElement("name", VariableManager.UserName),
                    new XElement("scoreCap", VariableManager.ScoreCapToggle)),
                    new XComment("End of Class")));
                document.Save(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                    "\\Library\\SpaceWarDefender\\SaveData\\UserSettings.xml");
            }
            else if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
            "\\Library\\SpaceWarDefender\\SaveData\\UserSettings.xml"))
            {
                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("userSettings",
                    new XComment("DO NOT EDIT THIS FILE UNLESS ISSUES OCCUR IN THE SETTINGS OF THE GAME!"),
                    new XComment("Setting for the profile or user of the game."),
                    new XElement("profile",
                    new XElement("name", VariableManager.UserName),
                    new XElement("scoreCap", VariableManager.ScoreCapToggle)),
                    new XComment("End of Class")));
                document.Save(Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
                    "\\Library\\SpaceWarDefender\\SaveData\\UserSettings.xml");
            }
        }

        setName.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int index)
    {
        Application.LoadLevel(index);
    }
}