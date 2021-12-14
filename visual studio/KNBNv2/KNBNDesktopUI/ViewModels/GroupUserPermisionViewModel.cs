using Caliburn.Micro;
using KNBNDesktopUI.Library.Api;
using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KNBNDesktopUI.ViewModels
{
    public class GroupUserPermisionViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private readonly IGroupEndpoint _groupEndpoint;


        public GroupUserPermisionViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint)
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
            _groupEndpoint = groupEndpoint;
        }

        //run when the viwe is loadet
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            try
            {
                await LoadGroups();
                await LoadUserPermision();

            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                switch (ex.Message)
                {
                    case "Unauthorized":
                        _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");

                        await _window.ShowDialogAsync(_status, null, settings);
                        break;

                    case "Internal Server Error":
                        _status.UpdateMessage("Internal Server Error", "You shall not passed!");
                        await _window.ShowDialogAsync(_status, null, settings);
                        break;

                    default:
                        break;
                }
            }
        }

        // Load all groups, and run on load
        private async Task LoadGroups()
        {
            var groupList = await _groupEndpoint.GetAll();
            Groups = new BindingList<GroupModel>(groupList);
        }

        // run when a group is selected
        private async Task LoadUsers()
        {
            if (SelectedGroup != null)
            {
                var userInGroupList = await _groupEndpoint.GetAllUsers(SelectedGroup.Id, true);
                var UserNotInGroupList = await _groupEndpoint.GetAllUsers(SelectedGroup.Id, false);
                UsersInGroup = new BindingList<UserModel>(userInGroupList);
                Users = new BindingList<UserModel>(UserNotInGroupList);
            }

        }


        private async Task LoadUserPermision()
        {
            var userPermision = await _groupEndpoint.GetAllPermissions();
            GroupPermission = new BindingList<GroupPermisionModel>(userPermision);
        }


        #region Load in all Groups in database
        // load in all group to select
        private BindingList<GroupModel> _groups;
        public BindingList<GroupModel> Groups
        {
            get
            {
                return _groups;
            }
            set
            {
                _groups = value;
                NotifyOfPropertyChange(() => Groups);
                NotifyOfPropertyChange(() => SelectedGroupName);

            }
        }


        // get the selected group and set it's name (SelectedGroupName)
        // and load in all users in the group and all not in the group
        private GroupModel _selectedGroup;
        public GroupModel SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                try
                {
                    SelectedGroupName = value.Name;
                    SelectedUsersPermision = "";
                    
                }
                catch (Exception)
                {
                    SelectedGroupName = "";
                }


                _ = LoadUsers();
                // _ = LoadUserPermision();

                NotifyOfPropertyChange(() => SelectedGroup);
                NotifyOfPropertyChange(() => SelectedUsersPermision);

            }
        }


        #region get and set name of the selected group

        // change the text in textbox to the selected user


        private string _selectedGroupName;

        public string SelectedGroupName
        {
            get { return _selectedGroupName; }
            set
            {
                _selectedGroupName = value;
                NotifyOfPropertyChange(() => SelectedGroupName);
            }
        }


        #endregion


        #endregion

        #region Load in all users in selected group
        private BindingList<UserModel> _usersInGroup { get; set; }

        public BindingList<UserModel> UsersInGroup
        {
            get
            {
                return _usersInGroup;
            }
            set
            {
                _usersInGroup = value;
                NotifyOfPropertyChange(() => UsersInGroup);
            }
        }

        #endregion

        #region Load in all users not in selecte group
        private BindingList<UserModel> _users;

        public BindingList<UserModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }
        #endregion

        private BindingList<GroupPermisionModel> _groupPermission;

        public BindingList<GroupPermisionModel> GroupPermission
        {
            get { return _groupPermission; }
            set
            {
                _groupPermission = value;
                NotifyOfPropertyChange(() => GroupPermission);
                NotifyOfPropertyChange(() => SelectedGroupPermission);
            }
        }



        #region group edditer

        private string _groupName;

        public string GroupName
        {
            get
            {
                _ = SearchGroupName();
                return _groupName;
            }
            set
            {
                _groupName = value;
                NotifyOfPropertyChange(() => GroupName);
                _ = SearchGroupName();
            }
        }





        #endregion

        #region group-User edditer

        private UserModel _selectedUsersInGroup;

        public UserModel SelectedUsersInGroup
        {
            get { return _selectedUsersInGroup; }
            set
            {
                _selectedUsersInGroup = value;
                //var su = GetUserPermission(SelectedGroup.Id, SelectedUsersInGroup.Id);


                // TODO Get users permission
                NotifyOfPropertyChange(() => SelectedUsersInGroup);
                if (SelectedGroup != null  && SelectedUsersInGroup != null)
                {
                    SelectedUsersPermision = value.UserName; //su.Title; //value.FirstName; // ""; //su.Result.Title;
                }
                NotifyOfPropertyChange(() => SelectedUsersPermision);
            }
        }

        
        public GroupUserPermissionModel GetUserPermission(int groupId, string userId)
        {
            var tt = _groupEndpoint.GetUsersPermission(groupId, userId);

            return tt.Result.FirstOrDefault();
        }
        

        // Search function
        #region groupMember Search
        private string _groupMamperName;

        public string GroupMamperName
        {
            get { return _groupMamperName; }
            set
            {
                _groupMamperName = value;
                NotifyOfPropertyChange(() => GroupMamperName);
                _ = SearchUserIngroup();
            }
        }
        #endregion


        public async Task RemoveFromGroup()
        {

            try
            {
                if (SelectedGroup != null && SelectedUsersInGroup != null)
                {
                    await _groupEndpoint.RemoveUserFromGroup(SelectedGroup.Id, SelectedUsersInGroup.Id);
                    _ = LoadUsers();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*public async Task SearchMemper()
        {
            try
            {
                //await _groupEndpoint.UserLookup(SelectedGroup.Id, "");

                var userInGroup = await _groupEndpoint.UserInGroupLookup(SelectedGroup.Id, _groupMamperName);
                UsersInGroup.Clear();
                UsersInGroup = new BindingList<UserModel>(userInGroup);
            }
            catch (Exception)
            {

                throw;
            }
        }
        */

        #endregion

        #region User edditer

        private UserModel _selectedUser;

        public UserModel SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                NotifyOfPropertyChange(() => SelectedUser);
            }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public async Task AddUserToGroup()
        {
            try
            {
                if (SelectedGroup != null && SelectedUser != null)
                {
                    await _groupEndpoint.AddUserToGroup(SelectedGroup.Id, SelectedUser.Id);
                    _ = LoadUsers();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region all Search function
        private async Task SearchGroupName()
        {
            var getGroup = await _groupEndpoint.GroupLookup(_groupName);
            if (Groups is not null)
            {
                Groups.Clear();
            }
            if (UsersInGroup is not null)
            {
                UsersInGroup.Clear();
            }
            if (Users is not null)
            {
                Users.Clear();
            }

            //Groups.SelectMany(x => x.Name.Contains(_groupName));// .Where(x => x.Name.Contains(_groupName));// .Select(x => x.Name).ToList();
            Groups = new BindingList<GroupModel>(getGroup);
        }

        private async Task SearchUserIngroup()
        {
            var getUserInGroup = await _groupEndpoint.UserInGroupLookup(SelectedGroup.Id, _groupMamperName);
            UsersInGroup.Clear();
            UsersInGroup = new BindingList<UserModel>(getUserInGroup);
        }
        #endregion



        private GroupPermisionModel _selectedGroupPermission;
        public GroupPermisionModel SelectedGroupPermission
        {
            get { return _selectedGroupPermission; }
            set
            {
                _selectedGroupPermission = value;
                PrmisionInfo = value.Description;

            }
        }


        /*

        private BindingList<GroupPermisionModel> _groupPermission;

        public BindingList<GroupPermisionModel> GroupPermission
        {
            get { return _groupPermission; }
            set { _groupPermission = value; }
        }

        */

        private string _prmisionInfo;

        public string PrmisionInfo
        {
            get { return _prmisionInfo; }
            set
            {
                _prmisionInfo = value;
                NotifyOfPropertyChange(() => PrmisionInfo);
            }
        }



        private string _selectedUsersPermision;

        public string SelectedUsersPermision
        {
            get { return _selectedUsersPermision; }
            set
            {
                _selectedUsersPermision = value;
                NotifyOfPropertyChange(() => SelectedUsersPermision);
            }
        }





        //public async Task gf()
        //{
        //    dynamic settings = new ExpandoObject();
        //    settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        //    settings.ResizeMode = ResizeMode.NoResize;
        //    settings.Title = "System Error";
        //    _status.UpdateMessage("", "You shall not passed!");
        //    await _window.ShowDialogAsync(_status, null, settings);
        //}
    }
}
