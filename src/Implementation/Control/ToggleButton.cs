﻿using System.Xml.Linq;
using AddinX.Ribbon.Contract.Control.ToggleButton;
using AddinX.Ribbon.Contract.Enums;

namespace AddinX.Ribbon.Implementation.Control
{
    public class ToggleButton : Control, IToggleButton
    {
        private bool imageVisible;
        private string imageMso;
        private string imagePath;
        private bool showLabel;
        private string description;
        private string supertip;
        private ControlSize size;
        private string screentip;
        private string keytip;

        public ToggleButton()
        {
            ElementName = "toggleButton";
            Id = new ElementId();
            imageVisible = false;
            size = ControlSize.normal;
            showLabel = true;
        }

        protected internal IToggleButtonId SetLabel(string value)
        {
            Label = value;
            return this;
        }

        protected internal override XElement ToXml(XNamespace ns)
        {
            var tmpId = (ElementId) Id;
            var element = new XElement(ns + ElementName
                , new XAttribute(tmpId.Type.ToString(), tmpId.Value)
                , new XAttribute("label", Label)
                , imageVisible
                    ? string.IsNullOrEmpty(imageMso)
                        ? new XAttribute("image", imagePath)
                        : new XAttribute("imageMso", imageMso)
                    : new XAttribute("showImage", "false")
                , new XAttribute("showLabel", showLabel)
                , new XAttribute("size", size.ToString())
                , new XAttribute("getEnabled", "GetEnabled")
                , new XAttribute("getVisible", "GetVisible")
                , new XAttribute("onAction", "OnActionPressed")
                , new XAttribute("getPressed", "GetPressed")
                , new XAttribute("tag", tmpId.Value)
                );

            if (!string.IsNullOrEmpty(screentip))
            {
                element.Add(new XAttribute("screentip", screentip));
            }

            if (!string.IsNullOrEmpty(supertip))
            {
                element.Add(new XAttribute("supertip", supertip));
            }

            if (!string.IsNullOrEmpty(keytip))
            {
                element.Add(new XAttribute("keytip", keytip));
            }

            if (!string.IsNullOrEmpty(description))
            {
                element.Add(new XAttribute("description", description));
            }

            return element;
        }

        public IToggleButtonLabel SetId(string name)
        {
            Id = new ElementId().SetId(name);
            return this;
        }

        public IToggleButtonLabel SetIdMso(string name)
        {
            Id = new ElementId().SetMicrosoftId(name);
            return this;
        }

        public IToggleButtonLabel SetIdQ(string ns, string name)
        {
            Id = new ElementId().SetNamespaceId(ns, name);
            return this;
        }

        public IToggleButtonExtra ImageMso(string name)
        {
            imageVisible = true;
            imageMso = name;
            return this;
        }

        public IToggleButtonExtra ImagePath(string name)
        {
            imageVisible = true;
            imagePath = name;
            return this;
        }

        public IToggleButtonExtra NoImage()
        {
            imageVisible = false;
            return this;
        }

        public IToggleButtonSize ShowLabel()
        {
            showLabel = true;
            return this;
        }

        public IToggleButtonSize HideLabel()
        {
            showLabel = false;
            return this;
        }

        public IToggleButtonImage Large()
        {
            size = ControlSize.large;
            return this;
        }

        public IToggleButtonImage Normal()
        {
            size = ControlSize.normal;
            return this;
        }

        public IToggleButtonExtra Description(string description)
        {
            this.description = description;
            return this;
        }

        public IToggleButtonExtra Supertip(string supertip)
        {
            this.supertip = supertip;
            return this;
        }

        public IToggleButtonExtra Keytip(string keytip)
        {
            this.keytip = keytip;
            return this;
        }

        public IToggleButtonExtra Screentip(string screentip)
        {
            this.screentip = screentip;
            return this;
        }
    }
}