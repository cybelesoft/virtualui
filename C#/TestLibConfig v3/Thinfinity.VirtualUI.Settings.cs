using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Cybele.Thinfinity.Settings
{
    namespace VirtualUI
    {
        // Constants for enum Protocol
        public enum Protocol
        {
            PROTO_HTTP = 0,
            PROTO_HTTPS = 1
        }

        // Constants for enum ProfileKind
        public enum ProfileKind
        {
            PROFILE_APP = 0,
            PROFILE_WEBLINK = 1
        }

        // Constants for enum ScreenResolution
        public enum ScreenResolution
        {
            SCREENRES_Custom = 0,
            SCREENRES_FitToBrowser = 1,
            SCREENRES_FitToScreen = 2,
            SCREENRES_640x480 = 3,
            SCREENRES_800x600 = 4,
            SCREENRES_1024x768 = 5,
            SCREENRES_1280x720 = 6,
            SCREENRES_1280x768 = 7,
            SCREENRES_1280x1024 = 8,
            SCREENRES_1440x900 = 9,
            SCREENRES_1440x1050 = 10,
            SCREENRES_1600x1200 = 11,
            SCREENRES_1680x1050 = 12,
            SCREENRES_1920x1080 = 13,
            SCREENRES_1920x1200 = 14
        }

        // Constants for enum ServerSection
        public enum ServerSection
        {
            SRVSEC_GENERAL = 0,
            SRVSEC_RDS = 1,
            SRVSEC_APPLICATIONS = 2,
            SRVSEC_LICENSES = 3,
            SRVSEC_BROKER = 4,
            SRVSEC_AUTHENTICATION = 5,
            SRVSEC_FOLDERS = 6,
            SRVSEC_BRUTEFORCE = 7
        }

        // Constants for enum UserType
        public enum UserType
        {
            UT_USER = 0,
            UT_GROUP = 1
        }

        // Constants for enum AuthenticationMethod
        public enum AuthenticationMethod
        {
            AM_WINLOGON = 0,
            AM_RADIUS = 1,
            AM_DUO = 2,
            AM_SAML = 3,
            AM_OAUTH = 4,
            AM_EXTERNAL = 5
        }

        // Constants for enum AuthenticationMethod2FA
        public enum AuthenticationMethod2FA {
            AM2FA_TOTP = 0,
            AM2FA_DUO = 1
        }

        // Constants for enum ProfileCredentials
        public enum Credentials
        {
            CRED_AUTHENTICATED = 0,
            CRED_ASK = 1,
            CRED_SAVED = 2,
            CRED_SERVER = 3
        }

        // Constants for enum SetupMode
        public enum SetupMode
        {
            SETUP_NONE = 0,
            SETUP_STANDALONE = 1,
            SETUP_LOADBALANCING = 2
        }

        // Constants for enum SessionAccount
        public enum SessionAccount
        {
            SESSION_ACCOUNT_LOGGED = 0,
            SESSION_ACCOUNT_CUSTOM = 1,
            SESSION_ACCOUNT_CONSOLE = 2
        }

        // Constants for enum SessionMode
        public enum SessionMode
        {
            SESSION_MULTI_BROWSERS = 0,
            SESSION_ONE_BROWSER = 1
        }

        // Constants for enum RestrictionAction
        public enum RestrictionAction
        {
            RESTRICTION_NONE = 0,
            RESTRICTION_ALLOW = 1,
            RESTRICTION_BLOCK = 2
        }

        // Constants for enum LoadBalancingMethod
        public enum LoadBalancingMethod
        {
            BREADTH_FIRST = 0,
            DEPTH_FIRST = 1
        }

        // Constants for enum Service
        public enum Service
        {
            SVC_GATEWAY = 0,
            SVC_BROKER = 1,
            SVC_VIRTUALIZATION = 2
        }

        [Guid("845B4EE8-0F67-4D84-A4CE-642BBD520A47"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch), ComImport]
        public interface IServer
        {
            void Load();
            void Save();
            void HideSection(ServerSection section);
            void ShowSection(ServerSection section);
            IBinding Binding { get; }
            ICertificate Certificate { get; }
            IRDSAccounts RDSAccounts { get; }
            IProfiles Profiles { get; }
            ILicense License { get; }
            IGateways Gateways { get; }
            string NetworkID { get; set; }
            IAuthentication Authentication { get; }
            IRDS RDS { get; }
            string APIKey { get; set; }
            SetupMode SetupMode { get; }
            IBindings Bindings { get; }
            IBroker Broker { get; }
            IBruteForceDetection BruteForceDetection { get; }
            IBrokers SecondaryBrokers { get; }
            void EnableService(Service service, bool enable);
        }

        /// <summary>
        ///   Contains methods and properties to control the VirtualUI Server's
        ///   licence activation. The Activate method is used to register the Server
        ///   machine, with a combination of CustomerID and Serial.
        /// </summary>
        [Guid("A1DF5DC4-7157-4643-B28F-3B3D20A0E5C8"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ILicense
        {
            /// <summary>
            ///   Activates the Server's machine licence.
            /// </summary>
            /// <param name="customerId">
            ///   ID of the licence to register.
            /// </param>
            /// <param name="serial">
            ///   Serial number of the license.
            /// </param>
            /// <param name="resultCode">
            ///   Activation result code.
            /// </param>
            /// <param name="resultText">
            ///   Message about the error.
            /// </param>
            /// <returns>
            ///   True if license was successfully activated. False otherwise (check
            ///   resultCode and resultText in this case).
            /// </returns>
            bool Activate(string customerId, string serial, out int resultCode, out string resultText);

            /// <summary>
            ///   Deactivates the licence previously activated.
            /// </summary>
            void Deactivate();

            /// <summary>
            /// Using the Serial number property, gets from Activation Server the
            /// Manual Key for Server's machine. This key can be used to generate the
            /// license data needed to perform manual activation.
            /// </summary>
            /// <returns>
            /// The manual activation key.
            /// </returns>
            string GetManualActivationKey();

            /// <summary>
            /// Activates the Server's machine license manually.
            /// </summary>
            /// <param name="Data">License data received from Server. </param>
            /// <param name="resultCode">Activation result code. </param>
            /// <param name="resultText">Message about the error. </param>
            /// <returns>
            /// True if the license was successfully activated. False
            /// otherwise (in which case check resultCode and resultText).
            /// </returns>
            bool ActivateManual(string Data, out int resultCode, out string resultText);

            /// <summary>
            ///   ID of the current Server License.
            /// </summary>
            string CustomerID { get; set; }

            /// <summary>
            ///   Returns limits of the License, if any (ie, trial days, max servers,
            ///   max users per installation, etc).
            /// </summary>
            //TODO: int Limits[object name] { get; }

            /// <summary>
            ///   Returns custom features enabled on the License, if any.
            /// </summary>
            //TODO: int Features[object name] { get; }

            /// <summary>
            ///   Returns true if the current License is in trial mode.
            /// </summary>
            bool IsTrial { get; set; }

            /// <summary>
            ///   Returns true if the current License is valid (registered and not expired)
            /// </summary>
            bool IsValid { get; }

            /// <summary>
            ///   Serial number of the current License.
            /// </summary>
            string SerialStr { get; set; }

            /// <summary>
            ///   License Server URL (optional). To set Primary and Backup servers,
            ///   separate them with semicolon.
            ///   Example: https://primaryUrl:7443;https://backupUrl:7443
            /// </summary>
            string ServerUrl { get; set; }

            /// <summary>
            ///   License expiration date, in format YYYY-MM-DD.
            /// </summary>
            string Expiration { get; }
        }

        /// <summary>
        ///   Contains all properties of an application profile.
        /// </summary>
        [ComVisible(true), Guid("D478CC7A-8071-47BD-BA2D-845131B51B42"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IProfile
        {
            /// <summary>
            ///   Internal ID of the profile. This value is auto generated by the
            ///   library when the profile is created.
            /// </summary>
            string ID { get; set; }

            /// <summary>
            ///   Profile name. Is the caption for the Application or Web link in the
            ///   VirtualUI home page.
            /// </summary>
            string Name { get; set; }

            /// <summary>
            ///   The Virtual Path must be unique across all profiles. It will create a
            ///   unique URL address for the profile. The complete path will consist
            ///   of: http(s)://ip:port/VirtualPath/. The users can then create a web
            ///   shortcut to this connection in particular and bypass the Thinfinity
            ///   VirtualUI home page.
            /// </summary>
            string VirtualPath { get; set; }

            /// <summary>
            ///   This option is used to make this profile the default application: the
            ///   authenticated user will connect to this profile directly instead of
            ///   choosing between the available profiles on the VirtualUI home page.
            /// </summary>
            bool IsDefault { get; set; }

            /// <summary>
            ///   Enables or disables the profile. Disabled profiles are not accesible
            ///   by users.
            /// </summary>
            bool Enabled { get; set; }

            /// <summary>
            ///   Gets or sets the profile type: Application or Web Link. Uses the
            ///   constants PROFILE_App and PROFILE_WebLink.
            /// </summary>
            ProfileKind ProfileKind { get; set; }

            /// <summary>
            ///   Complete path of the application executable file. Only used when the
            ///   ProfileKind is Application.
            /// </summary>
            string FileName { get; set; }

            /// <summary>
            ///   Parameters to be passed to application.
            /// </summary>
            string Arguments { get; set; }

            /// <summary>
            ///   Application startup directory. In most cases, the same of application
            ///   executable file.
            /// </summary>
            string StartDir { get; set; }

            /// <summary>
            ///   A valid Windows User account to run the application.
            ///   Used when Credentials is CRED_SAVED.
            /// </summary>
            string UserName { get; set; }

            /// <summary>
            ///   Password of the Windows User account. Can be set, but not retrieved
            ///   for security reasons.
            ///   Used when Credentials is CRED_SAVED.
            /// </summary>
            string Password { get; set; }

            /// <summary>
            ///   Screen resolution in the browser. Uses the constants SCREENRES_...
            /// </summary>
            ScreenResolution ScreenResolution { get; set; }

            /// <summary>
            ///   Full URL of the Web Link (only used when ProfileKind is Web Link).
            /// </summary>
            string WebLink { get; set; }

            /// <summary>
            ///   Used to set a customized home page for the application.
            /// </summary>
            string HomePage { get; set; }

            /// <summary>
            ///   Set a timeout in minutes if you want VirtualUI Server to wait this
            ///   period before killing the application once the browser has been
            ///   closed. Timeout 0 will kill the application immediately after the
            ///   browser has been closed.
            /// </summary>
            int IdleTimeout { get; set; }

            /// <summary>
            ///   Contains the icon of the profile. This icon is visible in the
            ///   VirtualUI home page. The icon must be encoded in base64. To set the
            ///   icon from a PNG image, you can use the IconToBase64 function. To
            ///   convert the stored icon to a PNG image, can use the Base64ToIcon
            ///   function.
            /// </summary>
            string IconData { get; set; }

            /// <summary>
            ///   Profiles marked as not visible are hidden in home page.
            /// </summary>
            bool Visible { get; set; }

            /// <summary>
            /// Indicates anonymous access to this profile. If false, the
            /// users or groups in Users are used.
            /// </summary>
            bool GuestAllowed { get; set; }

            /// <summary>
            /// Users or Groups with granted access to this profile (only
            /// when GuestAllowed is false).
            /// </summary>
            IUsers Users { get; }

            /// <summary>
            /// Profile Access Key. Can be used for OTURL generation.
            /// </summary>
            string PublicKey { get; }

            /// <summary>
            /// Windows Credentials to run the application:
            ///   CRED_AUTHENTICATED: Use the authenticated user credentials
            ///   CRED_ASK: Ask for credentials
            ///   CRED_SAVED: Use the UserName and Password properties.
            ///   CRED_SERVER: Use the Server's RDS Account
            /// </summary>
            Credentials Credentials { get; set; }

            /// <summary>
            /// (optional) Pool Name of the Broker to use.
            /// </summary>
            string BrokerPool { get; set; }

            /// <summary>
            /// Custom Browser Rules file to apply in this Profile.
            /// </summary>
            string BrowserRules { get; set; }

            /// <summary>
            /// Allow to pass application arguments from browser
            /// </summary>
            bool AllowBrowserArguments { get; set; }

            /// <summary>
            /// Use of Restrictions list:
            ///   NONE: No restrictions. The addresses in Restrictions list are ignored.
            ///   ALLOW: Allow connections from addresses in Restrictions list only.
            ///   BLOCK: Block connections from addresses in Restrictions list.
            /// </summary>
            RestrictionAction RestrictionAction { get; set; }

            /// <summary>
            /// IP addresses Restrictions list. Used according to RestrictionAction.
            /// </summary>
            IStrList Restrictions { get; }

            /// <summary>
            /// Allow access to users authenticated through this methods only.
            /// No restrictions if the list is empty.
            /// </summary>
            IStrList AllowedAuthMethods { get; }

            /// <summary>
            /// Restricts access to profile based on day of the week and hour.
            /// This field is a string of 7x24 characters (representing 24 hours
            /// for Sunday, 24 for Monday, and so on). To allow connections to
            /// this profile the corresponding hour must be marked with "1"
            /// ("0" to block).
            /// </summary>
            string AccessHours { get; set; }

            /// <summary>
            /// Enables access restriction based on dates period (AccessDateFrom
            /// and AccessDateTo fields)
            /// </summary>
            bool AccessDateEnabled { get; set; }

            /// <summary>
            /// if AccessDateEnabled is true, the profile is not accessible
            /// prior to this date.
            /// </summary>
            string AccessDateFrom { get; set; }

            /// <summary>
            /// if AccessDateEnabled is true, the profile is not accessible
            /// past this date.
            /// </summary>
            string AccessDateTo { get; set; }
        }

        /// <summary>
        /// User for permissions settings.
        /// </summary>
        [Guid("0BA574FB-8F9D-4B7B-97FC-C869231B4E6E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IUser
        {
            /// <summary>
            /// User type: User name or Group name.
            /// </summary>
            UserType UserType { get; }

            /// <summary>
            /// Windows User or Group name.
            /// </summary>
            string SamCompatible { get; }
        }

        /// <summary>
        /// List of IUser.
        /// </summary>
        [Guid("751686C0-EA61-420F-A861-F8A7A8329307"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IUsers
        {
            /// <summary>
            /// Creates a new User and adds it to the list.
            /// </summary>
            /// <param name="UserType">
            ///   Indicates type of User that SamCompatible defines
            ///   (UserType enum: User or Group).
            /// </param>
            /// <param name="SamCompatible">
            ///   User or Group (according to UserType) to grant.
            /// </param>
            /// <returns>
            /// The newly created User.
            /// </returns>
            /// <seealso cref="IUser">
            ///   User interface.
            /// </seealso>
            IUser Add(UserType UserType, string SamCompatible);

            /// <summary>
            ///   Deletes a User from the list.
            /// </summary>
            /// <param name="UserType">
            ///   Indicates type of User that SamCompatible defines
            ///   (UserType enum: User or Group).
            /// </param>
            /// <param name="SamCompatible">
            ///   The User to be deleted.
            /// </param>
            bool Delete(UserType UserType, string SamCompatible);

            /// <summary>
            ///   Removes the User.
            /// </summary>
            bool Remove(IUser User);

            /// <summary>
            ///   Returns the Users count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns a User from the list by it's index.
            /// </summary>
            /// <seealso cref="IUser">
            ///   User interface.
            /// </seealso>
            IUser this[int index] { get; }
        }

        /// <summary>
        ///   Manages the list of profiles registered in the Server. A profile is one
        ///   application or web link configured to be opened in VirtualUI's home
        ///   page (or directly through it's URL). The method Add is used to create a
        ///   new empty profile in the VirtualUI Server. The properties of this
        ///   profile can be managed through the IProfile interface to complete
        ///   configuration of a new application or web link.
        /// </summary>
        [Guid("C271394D-82FA-4DF9-A603-9927AA76A4F9"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IProfiles
        {
            /// <summary>
            /// Creates a new profile and adds it to the list.
            /// </summary>
            /// <returns>
            /// The newly created profile.
            /// </returns>
            /// <seealso cref="IProfile interface"/>
            IProfile Add();

            /// <summary>
            ///   Deletes a profile from the list.
            /// </summary>
            /// <param name="profile">
            ///   The profile to be deleted.
            /// </param>
            void Delete(IProfile profile);

            /// <summary>
            ///   Returns the profile count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns a profile from the list by it's index.
            /// </summary>
            /// <seealso cref="IProfile interface"/>
            IProfile this[int index] { get; }
        }

        /// <summary>
        ///   Binding configuration.
        /// </summary>
        [Guid("52C63E8D-2FA4-4179-AFDB-2D33853F3356"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IBinding
        {
            /// <summary>
            ///   Gets o sets the network protocol: HTTP or HTTPS. Uses the constants
            ///   PROTO_HTTP and PROTO_HTTPS.
            /// </summary>
            Protocol Protocol { get; set; }

            /// <summary>
            ///   Gets o sets the local IP Address. Leave empty to use all
            ///   addresses.
            /// </summary>
            string IPAddress { get; set; }

            /// <summary>
            ///   Gets o sets the listening port.
            /// </summary>
            int Port { get; set; }

            /// <summary>
            /// Binding Hostname (optional). If used, clients must use the hostname
            /// instead of the IP address to access the site.
            /// </summary>
            string HostName { get; set; }

            /// <summary>
            /// URL to redirect requests received through this binding
            /// </summary>
            string RedirectUrl { get; set; }

            /// <summary>
            /// Status code used in redirection:
            ///   301: Permanent.
            ///   302: Found.
            ///   307: Temporary.
            ///   308: Redirect.
            /// </summary>
            int RedirectStatusCode { get; set; }

            /// <summary>
            /// Certificate for HTTPS. The certificate must be installed on Windows.
            /// CertificateUtils can be used to import or create new certificates.
            /// </summary>
            /// <seealso cref="ICertificateUtils interface" />
            ICertificateInfo Certificate { get; set; }
    }

        /// <summary>
        ///   Manage the Server's Binding configuration.
        /// </summary>
        [Guid("9F6F6EDA-F253-4A6B-B058-EDBBEFC2718D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IBindings {
            /// <summary>
            /// Creates a new binding.
            /// </summary>
            /// <returns>
            /// The newly created binding.
            /// </returns>
            /// <seealso cref="IBinding interface"/>
            IBinding Add();

            /// <summary>
            ///   Removes a binding from the list.
            /// </summary>
            /// <param name="binding">
            ///   The binding to be removed.
            /// </param>
            void Delete(IBinding binding);

            /// <summary>
            ///   Returns the bindings list count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns a binding from the list by it's index.
            /// </summary>
            /// <seealso cref="IBinding interface"/>
            IBinding this[int index] { get; }
        }

        /// <summary>
        /// DEPRECATED: Use Bindings instead.
        /// </summary>
        [Guid("8B534446-EDC5-4EE7-91B0-13B5DACC5B51"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ICertificate
        {
            string CertFile { get; set; }
            string CAFile { get; set; }
            string PKFile { get; set; }
            string PassPhrase { get; set; }
        }

        [Guid("1CA5335A-94E0-490E-9BB7-5C66026883D2"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAutoLogon
        {
            /// <summary>
            /// Enables or disables session AutoLogon.
            /// </summary>
            bool Enabled { get; set; }

            /// <summary>
            /// Username for session AutoLogon.
            /// </summary>
            string UserName { get; set; }

            /// <summary>
            /// Password for session AutoLogon.
            /// </summary>
            string Password { get; set; }

            /// <summary>
            /// Session shell.
            /// </summary>
            string Shell { get; set; }
        }

        /// <summary>
        ///   Manages the configuration of an alternative Remote Desktop Services
        ///   account. VirtualUI makes use of an interactive session. The default
        ///   setting is to run applications under the console session, but it can be
        ///   configured to do it under Remote Desktop Services sessions. For the
        ///   production environment, it is recommended to set VirtualUI to run
        ///   applications under its own Remote Desktop Services session. This will
        ///   ensure that the service is available at all times. Alternatively, you
        ///   can choose to have VirtualUI run the applications under the console
        ///   session by configuring the Auto Logon feature on your Windows operating
        ///   system.
        /// </summary>
        [Guid("103B86C8-E012-4AC7-A366-D3845BBB8D5E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IRDS
        {
            /// <summary>
            /// Enables or disables the use of RDS account. Available on Windows Server
            /// with Remote Desktop Session Host (RD Session Host) role service installed.
            /// </summary>
            [Obsolete("Enabled is deprecated. It's used internally based on other settings")]
            bool Enabled { get; set; }

            /// <summary>
            /// Gets o sets the RDS account Username.
            /// Used when SessionCount is SESSION_ACCOUNT_CUSTOM.
            /// </summary>
            string UserName { get; set; }

            /// <summary>
            /// Gets o sets the RDS account Password. Can be set, but is not
            /// retrieved for security reasons.
            /// Used when SessionCount is SESSION_ACCOUNT_CUSTOM.
            /// </summary>
            string Password { get; set; }

            /// <summary>
            /// DEPRECATED. Use SessionMode instead.
            /// </summary>
            [Obsolete("SessionSharing property is deprecated and not longer supported, please use SessionMode instead.")]
            bool SessionSharing { get; set; }

            /// <summary>
            /// DEPRECATED. Use UsersLimit on IBroker instead.
            /// </summary>
            [Obsolete("SessionCount property is deprecated and not longer supported, please use UsersLimit on IBroker instead.")]
            int SessionCount { get; set; }

            /// <summary>
            /// Account to use:
            ///   SESSION_ACCOUNT_CUSTOM: Use UserName and Password properties.
            ///   SESSION_ACCOUNT_LOGGED: Use the logged-on user account.
            ///   SESSION_ACCOUNT_CONSOLE: Run under the console session.
            /// </summary>
            SessionAccount SessionAccount { get; set; }

            /// <summary>
            /// Session mode:
            ///   SESSION_MULTI_BROWSERS: Shared session.
            ///   SESSION_ONE_BROWSER: One browser per session.
            /// </summary>
            SessionMode SessionMode { get; set; }

            /// <summary>
            /// </summary>
            bool ThirdPartyApps { get; set; }

            /// <summary>
            /// AutoLogon options for console session.
            /// </summary>
            IAutoLogon AutoLogon { get; }

            /// <summary>
            /// Creates a new RDS account using UserName and Password properties.
            /// </summary>
            void CreateAccount();
        }

        /// <summary>
        /// DEPRECATED: Use IRDS on IBroker instead.
        /// </summary>
        [Guid("60666BC2-7E17-4842-9716-CFA3DCFD5583"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IRDSAccounts
        {
            IRDS Add(string UserName, string Password, bool CreateAccount);
            bool Delete(string UserName, bool DeleteAccount);
            int Count { get; }
            IRDS this[int index] { get; }
        }

        /// <summary>
        ///   Manages the configuration of gateway servers.
        /// </summary>
        [Guid("716BBB17-7A57-46D1-93BB-2C8A947E1F6B"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IGateways
        {
            /// <summary>
            /// Adds a new URL to the gateway list.
            /// </summary>
            /// <param name="URL">
            ///   The Gateway URL to be added.
            /// </param>
            void Add(string URL);

            /// <summary>
            ///   Deletes an URL from the list.
            /// </summary>
            /// <param name="index">
            ///   The index of the URL to be deleted.
            /// </param>
            void Delete(int index);

            /// <summary>
            ///   Returns the URLs count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns an URL from the list by it's index.
            /// </summary>
            string this[int index] { get; }
        }

        [Guid("83CAE401-7FB8-49F9-AD27-DF3C783CB52B"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IPath
        {
            string Path { get; set; }
            string UserName { get; set; }
            string Password { get; set; }
        }

        /// <summary>
        ///   Manages Broker configuration.
        /// </summary>
        [Guid("A5B08CC6-00C2-44FB-8CAC-2C03C9BC7CE5"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IBroker {
            /// <summary>
            /// Broker role.
            /// <summary>
            bool Primary { get; set; }

            /// <summary>
            /// Users limit.
            /// </summary>
            int UsersLimit { get; set; }

            /// <summary>
            /// Pool name for non primary brokers. Leave emtpy to use default.
            /// </summary>
            string PoolName { get; set; }

            /// <summary>
            /// Breadth-first Load Balancing allows you to evenly distribute user
            /// sessions across the session hosts in a broker pool.
            /// Depth-first load balancing allows you to saturate a session host
            /// with user sessions in a broker pool.
            /// </summary>
            LoadBalancingMethod LoadBalancingMethod { get; set; }

            /// <summary>
            /// In secondary brokers pool, mark this pool as default.
            /// </summary>
            bool Default { get; set; }

            /// <summary>
            /// Session settings for broker or pool.
            /// </summary>
            IRDS RDS { get; }

            /// <summary>
            /// Folders settings for broker or pool.
            /// </summary>
            IPath TmpFiles { get; }
        }

        [Guid("2AC5773C-E1BF-4B10-B99F-E28E9A459C29"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IBrokers
        {
            IBroker Add();
            void Delete(IBroker broker);
            void Clear();
            int Count { get; }
            IBroker this[int index] { get; }
        }

        /// <summary>
        ///   Manages the configuration of an Authentication Method.
        /// </summary>
        [Guid("FCF2B73F-2BE2-4097-9FBA-DB0CB413A228"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAuthMethod
        {
            /// <summary>
            ///   Returns the ID of the Authentication Method.
            /// </summary>
            AuthenticationMethod MethodId { get; }

            /// <summary>
            ///   Gets or sets the Authentication Method name.
            /// </summary>
            string Name { get; set; }

            /// <summary>
            ///   Enables or disables the Authentication Method.
            /// </summary>
            bool Enabled { get; set; }

            /// <summary>
            ///   Returns true if the Authentication Method is read only. This applies
            ///   to the built-in methods: they can be disabled but not deleted.
            /// </summary>
            bool IsReadOnly { get; }

            /// <summary>
            ///   Contains the icon of the Authentication Method. This icon is used in the
            ///   VirtualUI home page. The icon must be encoded in base64. To set the
            ///   icon from a PNG image, you can use the IconToBase64 function. To
            ///   convert the stored icon to a PNG image, can use the Base64ToIcon
            ///   function.
            /// </summary>
            string Icon { get; set; }

            /// <summary>
            ///   Virtual Path for the Authentication Method.
            ///   Access the web with this path to bypass the method selection.
            /// </summary>
            string VirtualPath { get; set; }

            /// <summary>
            ///   Contains the specific settings for the Authentication Method, in the
            ///   form Name=Value separated by a new line (CRLF).
            /// </summary>
            string Settings { get; set; }

            /// <summary>
            ///   2FA Method name to use (none if empty). 2FA methods are
            ///   in IAuthentication.SecondFactorMethods list.
            /// </summary>
            string SecondFactorMethod { get; set; }
        }

        /// <summary>
        ///   List of Authentication methods.
        /// </summary>
        [Guid("21EB20DE-26DD-410C-B82D-4A7022BA7A59"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAuthMethods
        {
            /// <summary>
            ///   Adds a new Authentication Method.
            /// </summary>
            /// <param name="MethodId">
            ///   The ID of the Authentication Method to add.
            /// </param>
            /// <seealso cref="IAuthMethod interface"/>
            IAuthMethod Add(AuthenticationMethod MethodId);

            /// <summary>
            ///   Deletes an Authentication Method from the list.
            /// </summary>
            /// <param name="Method">
            ///   The Authentication Method to delete.
            /// </param>
            bool Remove(IAuthMethod Method);

            /// <summary>
            ///   Returns the Authentication Methods count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns an Authentication Method from the list by it's index.
            /// </summary>
            /// <seealso cref="IAuthMethod interface"/>
            IAuthMethod this[int index] { get; }
        }

        /// <summary>
        ///   Manages the configuration of a Second Factor Authentication Method.
        /// </summary>
        [Guid("5BB4FF42-4D4D-4775-BE40-26DDBB6806C0"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAuthMethod2FA {
            /// <summary>
            ///   Gets the Authentication Method name.
            /// </summary>
            string Name { get; }

            /// <summary>
            ///   Contains the specific settings for the Authentication Method, in the
            ///   form Name=Value separated by a new line (CRLF).
            /// </summary>
            string Settings { get; set; }

            /// <summary>
            ///   Enables or disables this 2FA method.
            /// </summary>
            bool Enabled { get; set; }

            /// <summary>
            ///   Reset Two-Factor key stored on Server for the given UserName.
            /// </summary>
            void ResetKey(string UserName);
        }

        /// <summary>
        ///   List of 2FA methods.
        /// </summary>
        [Guid("25C1AB81-7578-4249-BCE7-A9C8DD4A8BA9"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAuthMethods2FA {
            /// <summary>
            ///   Adds a new Second Factor Authentication Method.
            /// </summary>
            /// <param name="MethodId">
            ///   The ID of the Authentication Method to add.
            /// </param>
            /// <seealso cref="IAuthMethod2FA interface"/>
            IAuthMethod2FA Add(AuthenticationMethod2FA MethodId);

            /// <summary>
            ///   Deletes an Second Factor Authentication Method from the list.
            /// </summary>
            /// <param name="Method">
            ///   The 2FA Method to delete.
            /// </param>
            bool Remove(IAuthMethod2FA Method);

            /// <summary>
            ///   Returns the 2FA Methods count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns a 2FA Method from the list by it's index.
            /// </summary>
            /// <seealso cref="IAuthMethod2FA interface"/>
            IAuthMethod2FA this[int index] { get; }
        }

        /// <summary>
        ///   Manages the Server authentication settings.
        /// </summary>
        [Guid("FEC05713-8C95-4A12-805A-CC3B11571501"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAuthentication
        {
            /// <summary>
            ///   Enables or disables the anonymous access to the Server home page.
            /// </summary>
            bool AllowAnonymous { get; set; }

            /// <summary>
            ///   Returns the SSO user mappings. This can be used to map usernames
            ///   used in SSO authentication methods to Windows user names or
            ///   groups, used in profiles permissions.
            /// </summary>
            /// <seealso cref="ISSOUsers interface"/>
            ISSOUsers SSOUsers { get; }

            /// <summary>
            ///   Returns the available Authentication Methods on the Server.
            /// </summary>
            /// <seealso cref="IAuthMethods interface"/>
            IAuthMethods AuthMethods { get; }

            /// <summary>
            ///   Methods for Two-Factor authentication. Used in IAuthMethod.
            /// </summary>
            IAuthMethods2FA SecondFactorMethods { get; }
        }

        /// <summary>
        /// List of ISSOUser. Manages the SSO user mappings.
        /// </summary>
        [Guid("5B1D5A75-BBED-4694-8AE0-6EB944DF6318"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ISSOUsers
        {
            /// <summary>
            ///   Creates a new Associated User and adds it to the list.
            /// </summary>
            /// <param name="RemoteUser">
            ///   Remote Username mask
            /// </param>
            /// <param name="MethodId">
            ///   MethodId to match. Can be one of the Authentication Methods
            ///   configured in Server (like Google, Facebook, etc) or * to match all
            /// </param>
            /// <param name="Enabled">
            ///   Indicates if the mapping is enabled or disabled.
            /// </param>
            /// <returns>
            ///   The newly created SSO User mapping.
            /// </returns>
            /// <seealso cref="ISSOUser interface"/>
            ISSOUser Add(string RemoteUser, string MethodId, bool Enabled);

            /// <summary>
            ///   Deletes a SSO User mapping from the list, based on RemoteUser+MethodId.
            /// </summary>
            bool Delete(string RemoteUser, string MethodId);

            /// <summary>
            ///   Removes the SSO User mapping.
            /// </summary>
            bool Remove(ISSOUser SSOUser);

            /// <summary>
            ///   Returns the mappings count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns a SSO User mapping from the list by it's index.
            /// </summary>
            /// <seealso cref="ISSOUser interface"/>
            ISSOUser this[int index] { get; }
        }

        /// <summary>
        ///   Manages one SSO user mapping.
        /// </summary>
        [Guid("25D8274E-75C2-4AC6-B95C-EA146B138AAE"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ISSOUser
        {
            /// <summary>
            ///   Remote Username mask to match
            /// </summary>
            string RemoteUser { get; }

            /// <summary>
            ///   MethodId to match. Can be one of the Authentication Methods
            ///   configured in Server (like Google, Facebook, etc) or * to match all
            /// </summary>
            string MethodId { get; }

            /// <summary>
            ///   Enables or disables this mapping
            /// </summary>
            bool Enabled { get; set; }

            /// <summary>
            ///   Users or Groups mapped to this RemoteUser/MethodId
            /// </summary>
            /// <seealso cref="IAssociatedUserAccounts interface"/>
            IAssociatedUserAccounts AssociatedUserAccounts { get; }

            /// <summary>
            /// (optional) Custom Windows Credentials to use.
            /// </summary>
            string WinUsername { get; set; }

            /// <summary>
            /// (optional) Custom Windows Credentials to use. Password can
            /// be set, but is not retrieved for security reasons.
            /// </summary>
            string WinPassword { get; set; }
        }

        /// <summary>
        ///   Manages user accounts associated to a SSO user mapping.
        /// </summary>
        [Guid("A230AD4D-104A-4444-ADBD-259D5243A485"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAssociatedUserAccounts
        {
            /// <summary>
            ///   Creates a new Associated User and adds it to the list.
            /// </summary>
            /// <param name="UserType">
            ///   Indicates type of User that SamCompatible defines
            ///   (UserType enum: User or Group).
            /// </param>
            /// <param name="SamCompatible">
            ///   User or Group (according to UserType) to grant.
            /// </param>
            /// <returns>
            ///   The newly created Associated User.
            /// </returns>
            /// <seealso cref="IAssociatedUserAccount interface"/>
            IAssociatedUserAccount Add(UserType userType, string SamCompatible);

            /// <summary>
            ///   Deletes a Associated User from the list.
            /// </summary>
            /// <param name="UserType">
            ///   Indicates type of User that SamCompatible defines
            ///   (UserType enum: User or Group).
            /// </param>
            /// <param name="SamCompatible">
            ///   The User to be deleted.
            /// </param>
            bool Delete(UserType userType, string SamCompatible);

            /// <summary>
            ///   Removes the Associated User.
            /// </summary>
            bool Remove(IAssociatedUserAccount User);

            /// <summary>
            ///   Returns the Associated Users count.
            /// </summary>
            int Count { get; }

            /// <summary>
            ///   Returns a Associated User from the list by it's index.
            /// </summary>
            /// <seealso cref="IAssociatedUserAccount interface"/>
            IAssociatedUserAccount this[int index] { get; }
        }

        /// <summary>
        ///   Manages a associated account to a SSO user mapping.
        /// </summary>
        [Guid("99D48E0A-0C91-494C-9A2C-B67BC782B3C2"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IAssociatedUserAccount
        {
            /// <summary>
            ///   Indicates type of User that SamCompatible defines
            ///   (UserType enum: User or Group).
            /// </summary>            
            UserType UserType { get; }

            /// <summary>
            ///   User or Group (according to UserType).
            /// </summary>
            string SamCompatible { get; }
        }

        /// <summary>
        /// Generic list of strings used by some interfaces.
        /// </summary>
        [Guid("B40601EE-2E1D-4973-9752-A80D1C00FAD2"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IStrList {
            void Add(string Value);
            void Delete(int Index);
            int Count { get; }
            string this[int index] { get; }
            void Clear();
            bool Contains(string Value);
        }

        /// <summary>
        /// IP Address/Mask item. Used in IIPList for IBruteForceDetection properties.
        /// </summary>
        [Guid("F2F2F071-D5DB-4FB1-A2DE-D9976F359946"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IIPListItem {
            /// <summary>
            /// IP Address or Mask
            /// </summary>
            string Address { get; set; }

            /// <summary>
            /// True if item was added manually, False otherwise.
            /// Not persistent items are added at runtime.
            /// </summary>
            bool Persistent { get; }

            /// <summary>
            /// Item Expiration Date, in format YYYY-MM-DD HH:MM:SS
            /// </summary>
            string Expiration { get; }
        }

        /// <summary>
        /// List of IIPListItem, used in IBruteForceDetection properties.
        /// </summary>
        [Guid("8DF9476B-DD60-44B6-B240-210B64CA7D4E"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IIPList {
            /// <summary>
            ///   Add IP Address or Mask to list.
            /// </summary>
            /// <returns>
            ///   The newly created item.
            /// </returns>
            /// <seealso cref="IIPListItem interface"/>
            IIPListItem Add(string Address);

            /// <summary>
            /// Removes IP item from the list by it's index.
            /// </summary>
            void Delete(int Index);

            /// <summary>
            /// Returns items Count.
            /// </summary>
            int Count { get; }

            /// <summary>
            /// Returns a IP item from the list by it's index.
            /// </summary>
            /// <seealso cref="IIPListItem interface"/>
            IIPListItem this[int index] { get; }
        }

        /// <summary>
        /// Brute Force detection configuration. If enabled, after a number of invalid
        /// login attempts IP addresses will be blocked for a time
        /// </summary>
        [Guid("B3D8EE8F-2892-44AE-B037-728BB8E25B6D"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IBruteForceDetection {
            /// <summary>
            /// Enables Brute Force detection
            /// </summary>
            bool Enabled { get; set; }

            /// <summary>
            /// Max failed login attempts. When reached, the origin IP address is
            /// blocked (if not included in whitelist).
            /// </summary>
            int MaxLoginAttempts { get; set; }

            /// <summary>
            /// Block time, in minutes, for IP addresses thath reaches MaxLoginAttempts
            /// </summary>
            int BlockTime { get; set; }

            /// <summary>
            /// Addresses in this list are never blocked. Local IP addresses are
            /// added at runtime and cannot be removed.
            /// </summary>
            /// <seealso cref="IIPList interface"/>
            IIPList WhiteList { get; }

            /// <summary>
            /// Currently blocked IP addresses. When BlockTime elapses, IP are removed
            /// from list and can login again.
            /// Addresses manually added (persistent) are not removed.
            /// </summary>
            /// <seealso cref="IIPList interface"/>
            IIPList BlackList { get; }
        }

        [Guid("8399F246-FE06-4F8F-B98E-85551B57756A"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ICertificateUtils {
            ICertificateInfoList GetCertificates();
            ICertificateInfo GetCertificateInfo(string CertificateStore, string Thumbprint);
            bool ImportCertificate(string FileName, string Password, out string Thumbprint, out string CertificateStore);
            bool CreateSelfSignedCertificate(string OutputfileName, string Password, string CommonName, string Country, string State,
                                             string Locality, string Organization, string OrganizationalUnit, string EmailAddress, int KeySize,
                                             out string Thumbprint, out string CertificateStore);
        }

        /// <summary>
        /// Certificate information.
        /// </summary>
        [Guid("F721D26C-AD65-4535-8331-9D78F20D37FA"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ICertificateInfo {
            string CommonName { get; }
            string IssuedTo { get; }
            string ExpirationDate { get; }
            string FriendlyName { get; }
            string CertificateStore { get; }
            string IssuedBy { get; }
            string Thumbprint { get; }
            string DisplayName { get; }
        }

        /// <summary>
        /// List of certificates.
        /// </summary>
        [Guid("802FD3E5-C8B0-4A3A-9C76-086BFCD2E900"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface ICertificateInfoList {
            void Add(ICertificateInfo item);
            int Count { get; }
            ICertificateInfo this[int index] { get; }
        }

        public class VirtualUISLibrary
        {
            [DllImport("kernel32.dll")]
            private static extern IntPtr LoadLibrary(string dllToLoad);
            [DllImport("kernel32.dll")]
            protected static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);
            [DllImport("kernel32.dll")]
            private static extern bool FreeLibrary(IntPtr hModule);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

            protected static IntPtr LibHandle = IntPtr.Zero;
            protected static int RefCount = 0;

            public VirtualUISLibrary()
            {
                RefCount++;
                if (LibHandle == IntPtr.Zero)
                {
                    string TargetDir = GetDLLDir();
                    if (TargetDir != null)
                    {
                        string LibFilename = TargetDir + @"\Thinfinity.VirtualUI.Settings.dll";
                        LibHandle = LoadLibrary(LibFilename);
                    }
                }
            }

            ~VirtualUISLibrary() {
                RefCount--;
                if ((RefCount == 0 ) && (LibHandle != IntPtr.Zero)) {
                    FreeLibrary(LibHandle);
                }
            }

            /// <summary>
            ///   Returns the path where Thinfinity.VirtualUI.Settings.dll is located.
            /// </summary>
            private static string GetDLLDir()
            {
                RegistryKey RegKey = null;
                string IniFileName = AppDomain.CurrentDomain.BaseDirectory + "\\OEM.ini";
                if (File.Exists(IniFileName))
                {
                    StringBuilder sbOEMKey32 = null;
                    StringBuilder sbOEMKey64 = null;
                    sbOEMKey32 = new StringBuilder(1024);
                    sbOEMKey64 = new StringBuilder(1024);
                    GetPrivateProfileString("PATHS", "Key32", "", sbOEMKey32, sbOEMKey32.Capacity, IniFileName);
                    GetPrivateProfileString("PATHS", "Key64", "", sbOEMKey64, sbOEMKey64.Capacity, IniFileName);
                    if (sbOEMKey32.ToString() != "" && RegKey == null)
                    {
                        string oemKey32 = sbOEMKey32.ToString();
                        if (oemKey32.StartsWith("\\"))
                            oemKey32 = oemKey32.Substring(1);
                        RegKey = Registry.LocalMachine.OpenSubKey(oemKey32, false);
                    }

                    if (sbOEMKey64.ToString() != "" && RegKey == null)
                    {
                        string oemKey64 = sbOEMKey64.ToString();
                        if (oemKey64.StartsWith("\\"))
                            oemKey64 = oemKey64.Substring(1);
                        RegKey = Registry.LocalMachine.OpenSubKey(oemKey64, false);
                    }
                }
                if (RegKey == null)
                    RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Cybele Software\Setups\Thinfinity\VirtualUI", false);
                if (RegKey == null)
                    RegKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Cybele Software\Setups\Thinfinity\VirtualUI", false);
                if (RegKey != null)
                {
                    if (IntPtr.Size == 8)
                        return (string)RegKey.GetValue("TargetDir_x64", null);
                    else
                        return (string)RegKey.GetValue("TargetDir_x86", null);
                }
                else return ".";
            }
        }


        /// <summary>
        ///   Main class. Contains methods and properties to manage all Server
        ///   configuration.
        /// </summary>
        public class Server : VirtualUISLibrary, IServer , IDisposable
        {
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int funcGetInstance(ref IServer vui);
            private funcGetInstance GetInstance;
            private IServer m_Server;

            public Server()
                : base() {
                if (LibHandle != IntPtr.Zero) {
                    IntPtr pAddressOfFunctionToCall = GetProcAddress(LibHandle, "DllGetInstance");
                    GetInstance = (funcGetInstance)Marshal.GetDelegateForFunctionPointer(
                        pAddressOfFunctionToCall,
                        typeof(funcGetInstance));
                    GetInstance(ref m_Server);
                }
            }

            ~Server() {
                Dispose();
            }

            public void Dispose() {
                if (m_Server != null) {
                    Marshal.ReleaseComObject(m_Server);
                }
                m_Server = null;
            }

            /// <summary>
            /// DEPRECATED: use Bindings instead.
            /// </summary>
            /// <seealso cref="IBinding interface" />
            [Obsolete("Binding property is deprecated, please use Bindings instead.")]
            public IBinding Binding {
                get {
                    if (m_Server != null)
                        return m_Server.Binding;
                    else
                        return null;
                }
            }
            /// <summary>
            /// DEPRECATED: Not longer supported. Use Bindings instead.
            /// </summary>
            /// <seealso cref="ICertificate interface"/>
            [Obsolete("Certificate property is deprecated and not longer supported, please use Bindigns instead.")]
            public ICertificate Certificate {
                get {
                    if (m_Server != null)
                        return m_Server.Certificate;
                    else
                        return null;
                }
            }

            /// <summary>
            /// DEPRECATED: Not longer supported. Use RDS on IBroker instead.
            /// </summary>
            /// <seealso cref="IRDSAccounts interface"/>
            [Obsolete("RDSAccounts property is deprecated, please use RDS on IBroker instead.")]
            public IRDSAccounts RDSAccounts {
                get {
                    if (m_Server != null)
                        return m_Server.RDSAccounts;
                    else
                        return null;
                }
            }

            /// <summary>
            /// DEPRECATED: Not longer supported. Use RDS on IBroker instead.
            /// </summary>
            /// <seealso cref="IRDS interface"/>
            [Obsolete("RDS property is deprecated, please use RDS on IBroker instead.")]
            public IRDS RDS {
                get {
                    if (m_Server != null)
                        return m_Server.RDS;
                    else
                        return null;
                }
            }

            /// <summary>
            ///   Returns the profiles list.
            /// </summary>
            /// <seealso cref="IProfiles interface"/>
            public IProfiles Profiles {
                get {
                    if (m_Server != null)
                        return m_Server.Profiles;
                    else
                        return null;
                }
            }

            /// <summary>
            ///   Returns the current Server's licence.
            /// </summary>
            /// <seealso cref="ILicense interface"/>
            public ILicense License {
                get {
                    if (m_Server != null)
                        return m_Server.License;
                    else
                        return null;
                }
            }

            /// <summary>
            ///   Returns the current Server's gateways.
            /// </summary>
            /// <seealso cref="IGateway interface"/>
            public IGateways Gateways {
                get {
                    if (m_Server != null)
                        return m_Server.Gateways;
                    else
                        return null;
                }
            }

            /// <summary>
            ///   Loads all the configuration entries and profiles from file.
            ///   It's automatically called by constructor.
            /// </summary>
            public void Load() {
                if (m_Server != null)
                    m_Server.Load();
            }

            /// <summary>
            ///   Saves the entire configuration parameters and profiles.
            /// </summary>
            public void Save() {
                if (m_Server != null)
                    m_Server.Save();
            }

            /// <summary>
            /// Hides a configuration section in the VirtualUI Server Manager GUI.
            /// </summary>
            /// <param name="section">The Server configuration section to hide to user:
            ///   SRVSEC_GENERAL: General tab, that contains the Binding configuration.
            ///   SRVSEC_RDS: Sessions configuration.
            ///   SRVSEC_APPLICATIONS: List of applications.
            ///   SRVSEC_LICENSES: License information.
            ///   SRVSEC_BROKER: Broker options.
            ///   SRVSEC_AUTHENTICATION: Authentication options, methods and user mappings.
            ///   SRVSEC_FOLDERS: Folder options.
            ///   SRVSEC_BRUTEFORCE: Brute force detection options.
            /// </param>         
            public void HideSection(ServerSection section) {
                if (m_Server != null)
                    m_Server.HideSection(section);
            }

            /// <summary>
            /// Makes visible a configuration section in the VirtualUI Server Manager GUI.
            /// </summary>
            /// <param name="section">The Server configuration section to show to user.
            ///   SRVSEC_GENERAL: General tab, that contains the Binding configuration.
            ///   SRVSEC_RDS: Sessions configuration.
            ///   SRVSEC_APPLICATIONS: List of applications.
            ///   SRVSEC_LICENSES: License information.
            ///   SRVSEC_BROKER: Broker options.
            ///   SRVSEC_AUTHENTICATION: Authentication options, methods and user mappings.
            ///   SRVSEC_FOLDERS: Folder options.
            ///   SRVSEC_BRUTEFORCE: Brute force detection options.
            /// </param>         
            public void ShowSection(ServerSection section) {
                if (m_Server != null)
                    m_Server.ShowSection(section);
            }

            /// <summary>
            /// Enables or disables VirtualUI Services in Service Manager.
            /// </summary>
            /// <param name="service">Service to enable or disable.
            ///   SVC_GATEWAY: Gateway service.
            ///   SVC_BROKER: Broker service.
            ///   SVC_VIRTUALIZATION: File and Registry virtualization service.
            /// </param>
            /// <param name="enable">True to enable, false to disable the Service.
            /// </param>
            public void EnableService(Service service, bool enable) {
                if (m_Server != null)
                    m_Server.EnableService(service, enable);
            }

            /// <summary>
            ///   Global Network ID. All the Gateway and Server installations involved
            ///   in a Load Balancing architecture share the same network ID.
            /// </summary>
            public string NetworkID {
                get {
                    if (m_Server != null)
                        return m_Server.NetworkID;
                    else
                        return "";
                }
                set {
                    if (m_Server != null)
                        m_Server.NetworkID = value;
                }
            }

            /// <summary>
            ///   Returns the Authentication settings
            /// </summary>
            /// <seealso cref="IAuthentication" />
            public IAuthentication Authentication {
                get {
                    if (m_Server != null)
                        return m_Server.Authentication;
                    else
                        return null;
                }
            }

            /// <summary>
            /// API Key. Used for OTURL creation.
            /// </summary>
            public string APIKey {
                get {
                    if (m_Server != null)
                        return m_Server.APIKey;
                    else
                        return "";
                }
                set {
                    if (m_Server != null)
                        m_Server.APIKey = value;
                }
            }

            /// <summary>
            /// VirtualUI installation mode: Standalone or Load Balancing.
            /// </summary>
            public SetupMode SetupMode {
                get {
                    if (m_Server != null)
                        return m_Server.SetupMode;
                    else
                        return SetupMode.SETUP_NONE;
                }
            }

            /// <summary>
            /// Binding configuration.
            /// </summary>
            /// <seealso cref="IBindings" />
            public IBindings Bindings {
                get {
                    if (m_Server != null)
                        return m_Server.Bindings;
                    else
                        return null;
                }
            }

            /// <summary>
            /// Broker options.
            /// </summary>
            /// <seealso cref="IBroker" />
            public IBroker Broker {
                get {
                    if (m_Server != null)
                        return m_Server.Broker;
                    else
                        return null;
                }
            }

            /// <summary>
            /// Brute Force detection configuration.
            /// </summary>
            /// <seealso cref="IBruteForceDetection" />
            public IBruteForceDetection BruteForceDetection {
                get {
                    if (m_Server != null)
                        return m_Server.BruteForceDetection;
                    else
                        return null;
                }
            }

            /// <summary>
            /// Secondary brokers pool configuration.
            /// </summary>
            public IBrokers SecondaryBrokers {
                get {
                    if (m_Server != null)
                        return m_Server.SecondaryBrokers;
                    else
                        return null;
                }
            }
        }

        /// <summary>
        /// Helper functions to manage Binding certificates.
        /// </summary>
        public class CertificateUtils : VirtualUISLibrary, ICertificateUtils, IDisposable {
            [UnmanagedFunctionPointer(CallingConvention.StdCall)]
            private delegate int funcGetInstance(ref ICertificateUtils certUtils);
            private funcGetInstance GetInstance;
            private ICertificateUtils m_CertificateUtils;

            public CertificateUtils()
                : base() {
                if (LibHandle != IntPtr.Zero) {
                    IntPtr pAddressOfFunctionToCall = GetProcAddress(LibHandle, "DllCertUtilsGetInstance");
                    GetInstance = (funcGetInstance)Marshal.GetDelegateForFunctionPointer(
                        pAddressOfFunctionToCall,
                        typeof(funcGetInstance));
                    GetInstance(ref m_CertificateUtils);
                }
            }

            ~CertificateUtils() {
                Dispose();
            }

            public void Dispose() {
                if (m_CertificateUtils != null) {
                    Marshal.ReleaseComObject(m_CertificateUtils);
                }
                m_CertificateUtils = null;
            }

            /// <summary>
            /// Returns available certificates installed on Windows. Only
            /// certificates in this list can be used for HTTPS binding configuration.
            /// </summary>
            /// <seealso cref="ICertificateInfoList interface"/>
            public ICertificateInfoList GetCertificates() {
                if (m_CertificateUtils != null)
                    return m_CertificateUtils.GetCertificates();
                else
                    return null;
            }

            /// <summary>
            /// Returns information for certificate that matches specified
            /// Store and Thumbprint.
            /// </summary>
            /// <seealso cref="ICertificateInfo interface"/>
            public ICertificateInfo GetCertificateInfo(string CertificateStore, string Thumbprint) {
                if (m_CertificateUtils != null)
                    return m_CertificateUtils.GetCertificateInfo(CertificateStore, Thumbprint);
                else
                    return null;
            }

            /// <summary>
            ///   Imports certificate from file. If success, returns CertificateStore and Thumbprint.
            /// </summary>
            /// <param name="FileName">
            ///   Certificate file to import.
            /// </param>
            /// <param name="Password">
            ///   Certificate password, if required. Used to import protected PFX files.
            /// </param>
            /// <param name="Thumbprint">
            ///   (output) Returns Thumbprint of imported certificate.
            /// </param>
            /// <param name="CertificateStore">
            ///   (output) Returns where certificate was stored.
            /// </param>
            public bool ImportCertificate(string FileName, string Password, out string Thumbprint, out string CertificateStore) {
                if (m_CertificateUtils != null)
                    return m_CertificateUtils.ImportCertificate(FileName, Password, out Thumbprint, out CertificateStore);
                else {
                    Thumbprint = "";
                    CertificateStore = "";
                    return false;
                }
            }

            /// <summary>
            ///   Creates and import a new Self-signed certificate with the specified
            ///   attributes. If success, returns CertificateStore and Thumbprint.
            /// </summary>
            /// <param name="OutputfileName">
            ///   Destination filename for certificate. If empty, a temp file will be used.
            /// </param>
            /// <param name="Password">
            ///   Password to be set in generated certificate file. Can be empty.
            /// </param>
            /// <param name="CommonName, Country, State, Locality, Organization, OrganizationalUnit, EmailAddress">
            ///   Certificate attributes.
            /// </param>
            /// <param name="KeySize">
            ///   KeySize. Use 2048 or higher.
            /// </param>
            /// <param name="Thumbprint">
            ///   (output) Returns Thumbprint of imported certificate.
            /// </param>
            /// <param name="CertificateStore">
            ///   (output) Returns where certificate was stored.
            /// </param>
            public bool CreateSelfSignedCertificate(string OutputfileName, string Password, string CommonName, string Country, string State,
                                             string Locality, string Organization, string OrganizationalUnit, string EmailAddress, int KeySize,
                                             out string Thumbprint, out string CertificateStore)
            {
                if (m_CertificateUtils != null)
                    return m_CertificateUtils.CreateSelfSignedCertificate(OutputfileName, Password, CommonName, Country, State,
                                             Locality, Organization, OrganizationalUnit, EmailAddress, KeySize, out Thumbprint, out CertificateStore);
                else {
                    Thumbprint = "";
                    CertificateStore = "";
                    return false;
                }
            }
        }

        /// <summary>
        ///   Helper functions.
        /// </summary>
        public class ServerUtils
        {
            /// <summary>
            ///   Runs an application in elevated mode. This mode is required
            ///   to save the Server's configuration in protected files.
            /// </summary>
            /// <param name="filename">Full path of application to execute.</param>
            /// <param name="Parameters">\Arguments. </param>
            /// <example>
            ///   In the main program of the application using this classes, you
            ///   can include:
            ///         if (args.Length == 0)
            ///             ServerUtils.RunAsAdmin(Application.ExecutablePath, "/edit");
            ///         else {
            ///             [...]
            ///         }
            /// </example>                                                 
            public static void RunAsAdmin(string fileName, string parameters) {
                var proc = new System.Diagnostics.ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Path.GetDirectoryName(fileName);
                proc.FileName = fileName;
                if (parameters != null && parameters.Length > 0) {
                    proc.Arguments = parameters;
                }
                proc.Verb = "runas";
                System.Diagnostics.Process.Start(proc);
            }

            /// <summary>
            ///   Converts the IProfile.IconData (base64 string) to a PNG image.
            /// </summary>
            /// <param name="data">
            ///   The image encoded in base64.
            /// </param>
            public static Image Base64ToIcon(string data)
            {
                Image res;
                if (data.StartsWith("data:image/png;base64")) {
                    data = data.Remove(0, 22);
                }
                byte[] bytes = Convert.FromBase64String(data);
                MemoryStream ms = new MemoryStream(bytes);
                res = Image.FromStream(ms);
                ms.Close();
                return res;
            }

            /// <summary>
            ///   Converts a PNG image to be stored in IProfile.IconData (as base64 string).
            /// </summary>
            /// param name="png">
            ///   The image to be encoded in base64.
            /// </param>
            public static string IconToBase64(Image png)
            {
                string res = "";
                MemoryStream ms = new MemoryStream();
                png.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] bytes = ms.ToArray();
                res = Convert.ToBase64String(bytes);
                ms.Close();
                return res;
            }
        }
    }
}