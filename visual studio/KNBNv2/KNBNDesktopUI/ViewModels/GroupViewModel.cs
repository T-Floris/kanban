using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KNBNDesktopUI.Library.Api;
using KNBNDesktopUI.Library.Models;
<<<<<<< HEAD
=======
using KNBNDesktopUI.Views;
>>>>>>> til_m

namespace KNBNDesktopUI.ViewModels
{
    public class GroupViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
<<<<<<< HEAD

        public GroupViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint)
=======
        private readonly IGroupEndpoint _groupEndpoint;
        private readonly GroupView _groupView;



        public GroupViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint, GroupView groupView)
>>>>>>> til_m
        {
            _status = status;
            _window = window;
            _userEndpoint = userEndpoint;
<<<<<<< HEAD
        }

=======
            _groupEndpoint = groupEndpoint;
            _groupView = groupView;
        }
        

        //run when the viwe is loadet
>>>>>>> til_m
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            try
            {
<<<<<<< HEAD

=======
                await LoadGroups();
                
>>>>>>> til_m
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

<<<<<<< HEAD
=======
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
                /*
>>>>>>> til_m
                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                    await _window.ShowDialogAsync(_status, null, settings);

                }
<<<<<<< HEAD
            }
        }

        // set op listbox
        private BindingList<string> _availableUsers = new BindingList<string>();

        private BindingList<string> _groups;        


        public BindingList<string> AvailableUsers
        {
            get { return _availableUsers; }
            set
            { 
                _availableUsers = value;
                NotifyOfPropertyChange(() => AvailableUsers);
            }
        }


        public BindingList<string> Groups
        {
            get 
            { 
                return _groups;
            }

            set 
            { 
                _groups = value;
                NotifyOfPropertyChange(() => Groups);
            }
        }


        /*
        private async Task LoadUsers()
        {
            var users = await _userEndpoint.GetAll
        }
        */

        /*
        private async Task LoadGroups()
        {
            var groupList = await _
        }
        */

=======
                */
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
                var userInGroupList = await _groupEndpoint.GetAllUsersInGroup(SelectedGroup.Id);
                var UserNotInGroupList = await _groupEndpoint.GetAllUsersNotInGroup(SelectedGroup.Id);
                UsersInGroup = new BindingList<UserModel>(userInGroupList);
                Users = new BindingList<UserModel>(UserNotInGroupList);
            }

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
                    SelectedGroupName ??= value.Name;
                }
                catch (Exception)
                {
                    SelectedGroupName = "";
                }
                

                _ = LoadUsers();

                NotifyOfPropertyChange(() => SelectedGroup);
                
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
                NotifyOfPropertyChange(() => SelectedUsersInGroup);
            }
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
                _ = SearchUserNotIngroup();
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
        /*
        public async Task SearchUser()
        {
            var user = await _groupEndpoint.UserNotInGroupLookup(SelectedGroup.Id, _groupMamperName);
            UsersInGroup.Clear();
            UsersInGroup = new BindingList<UserModel>(user);
        }
        */
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

            Groups = new BindingList<GroupModel>(getGroup);
        }

        private async Task SearchUserIngroup()
        {
            var getUserInGroup = await _groupEndpoint.UserInGroupLookup(SelectedGroup.Id, _groupMamperName);
            UsersInGroup.Clear();
            UsersInGroup = new BindingList<UserModel>(getUserInGroup);
        }

        private async Task SearchUserNotIngroup()
        {
            var getUserNotInGroup = await _groupEndpoint.UserNotInGroupLookup(SelectedGroup.Id, _userName);
            Users.Clear();
            Users = new BindingList<UserModel>(getUserNotInGroup);
        }


        #endregion





        /*

        //TODO Get all users in selected group



        //TODO Get all users not in selected group
        private BindingList<string> _availableUsers = new BindingList<string>();

        public BindingList<string> AvailableUsers
        {
            get { return _availableUsers; }
            set
            {
                _availableUsers = value;
                NotifyOfPropertyChange(() => AvailableUsers);
            }

        }




        #endregion
        */

        /* SQL CALL ON LOAD*/
>>>>>>> til_m
    }
}
