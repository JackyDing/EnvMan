/*
 * EnvMan - The Open-Source Windows Environment Variables Manager
 * Copyright (C) 2006-2009 Vlad Setchin <envman-dev@googlegroups.com>
 * Copyright (C) 2013 Jacky Ding <jackyfire@gmail.com>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
**/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace EnvManager
{
    public partial class FormAbout : Form
    {
        public FormAbout ( )
        {
            InitializeComponent();

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:
            //  - Project->Properties->Application->Assembly Information
            //  - AssemblyInfo.cs
            this.Text = String.Format( "About {0}", AssemblyTitle );
            this.lblProductName.Text = AssemblyProduct;
            this.lblVersion.Text = String.Format("Version {0} (Build {1})", 
                this.PackageVersion, AssemblyVersion);
            this.lblCopyright.Text = AssemblyCopyright;
            this.txtDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[ ] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyTitleAttribute ), false );
                // If there is at least one Title attribute
                if ( attributes.Length > 0 )
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = ( AssemblyTitleAttribute ) attributes[ 0 ];
                    // If it is not an empty string, return it
                    if ( titleAttribute.Title != "" )
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension( Assembly.GetExecutingAssembly().CodeBase );
            }
        }
        public string PackageVersion
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;

                return version.ToString();
            }
        }
        public Version AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[ ] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyDescriptionAttribute ), false );
                // If there aren't any Description attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Description attribute, return its value
                return ( ( AssemblyDescriptionAttribute ) attributes[ 0 ] ).Description;
            }
        }
        /// <summary>
        /// Gets the assembly file version.
        /// </summary>
        /// <value>The assembly file version.</value>
        public string AssemblyFileVersion
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }
        /// <summary>
        /// Gets the assembly informational version.
        /// </summary>
        /// <value>The assembly informational version.</value>
        public string AssemblyInformationalVersion
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyInformationalVersionAttribute)attributes[0]).InformationalVersion;
            }
        }
        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[ ] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyProductAttribute ), false );
                // If there aren't any Product attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Product attribute, return its value
                return ( ( AssemblyProductAttribute ) attributes[ 0 ] ).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[ ] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCopyrightAttribute ), false );
                // If there aren't any Copyright attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Copyright attribute, return its value
                return ( ( AssemblyCopyrightAttribute ) attributes[ 0 ] ).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[ ] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes( typeof( AssemblyCompanyAttribute ), false );
                // If there aren't any Company attributes, return an empty string
                if ( attributes.Length == 0 )
                    return "";
                // If there is a Company attribute, return its value
                return ( ( AssemblyCompanyAttribute ) attributes[ 0 ] ).Company;
            }
        }
        #endregion
    }
}
