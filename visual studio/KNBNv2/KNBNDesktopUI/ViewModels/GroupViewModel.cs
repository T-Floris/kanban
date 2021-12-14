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
using KNBNDesktopUI.Views;

namespace KNBNDesktopUI.ViewModels
{
    public class GroupViewModel : Screen
    {
        private readonly StatusInfoViewModel _status;
        private readonly IWindowManager _window;
        private readonly IUserEndpoint _userEndpoint;
        private readonly IGroupEndpoint _groupEndpoint;


        public GroupViewModel(StatusInfoViewModel status, IWindowManager window, IUserEndpoint userEndpoint, IGroupEndpoint groupEndpoint)
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
                    SelectedGroupName = value.Name;
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
                return _groupName;
            }
            set 
            { 
                _groupName = value;
                NotifyOfPropertyChange(() => GroupName);
            }
        }





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
        /*
        public async Task SearchUser()
        {
            var user = await _groupEndpoint.UserNotInGroupLookup(SelectedGroup.Id, _groupMamperName);
            UsersInGroup.Clear();
            UsersInGroup = new BindingList<UserModel>(user);
        }
        */
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
    }
}
