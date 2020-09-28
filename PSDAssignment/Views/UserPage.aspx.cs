using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PSDAssignment.Controller;

namespace PSDAssignment.Views
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["auth_user"] != null)
            {
                if (UserController.getUserByID(Convert.ToInt32(Session["auth_user"])).RoleID == 3)
                {
                    List<User> userList = UserController.getAllUsers();
                    for (int i = 0; i < userList.Count; i++)
                    {
                        TableRow newRow = new TableRow();
                        UserTable.Controls.Add(newRow);

                        TableCell userIDCell = new TableCell();
                        userIDCell.Controls.Add(new Label()
                        {
                            Text = userList.ElementAt(i).Id.ToString()
                        });
                        newRow.Cells.Add(userIDCell);

                        TableCell userNameCell = new TableCell();
                        userNameCell.Controls.Add(new Label()
                        {
                            Text = userList.ElementAt(i).Name.ToString()
                        });
                        newRow.Cells.Add(userNameCell);

                        TableCell userEmailCell = new TableCell();
                        userEmailCell.Controls.Add(new Label()
                        {
                            Text = userList.ElementAt(i).Email.ToString()
                        });
                        newRow.Cells.Add(userEmailCell);

                        List<Role> roles = RoleController.getAllRole();
                        TableCell RoleCell = new TableCell();
                        DropDownList role = new DropDownList() { ID = userList.ElementAt(i).Id.ToString() + "r" };

                        if (userList.ElementAt(i).Id != Convert.ToInt32(Session["auth_user"]))
                        {
                            foreach (Role x in roles)
                            {
                                role.Items.Add(x.Name);
                            }
                        }
                        String roleName = RoleController.getRoleByID(Convert.ToInt32(userList.ElementAt(i).RoleID)).Name;
                        role.Text = roleName;
                        RoleCell.Controls.Add(role);
                        role.AutoPostBack = true;
                        role.SelectedIndexChanged += new EventHandler(this.ChangeRole);
                        newRow.Cells.Add(RoleCell);

                        TableCell StatusCell = new TableCell();
                        DropDownList status = new DropDownList { ID = userList.ElementAt(i).Id.ToString() };
                        status.Items.Add("Active");
                        if (userList.ElementAt(i).Id != Convert.ToInt32(Session["auth_user"]))
                        {
                            status.Items.Add("Inactive");
                        }
                        
                        
                        status.Text = userList.ElementAt(i).Status;
                        status.AutoPostBack = true;
                        status.SelectedIndexChanged += new EventHandler(this.ChangeStatus);
                        

                        StatusCell.Controls.Add(status);
                        newRow.Cells.Add(StatusCell);

                    }
                }
                else {
                    Response.Redirect("Home.aspx");
                }
            }
            else Response.Redirect("Home.aspx");
        }
    public void ChangeRole(object sender, EventArgs e) {
        DropDownList dropdown = (DropDownList)sender;
        String id = dropdown.ID.Substring(0, dropdown.ID.IndexOf('r'));
        int userID = Int32.Parse(id);
        int roleID = RoleController.getRoleByName(dropdown.SelectedValue).Id;
        UserController.updateUserRole(userID, roleID);
    }
            public void ChangeStatus(object sender, EventArgs e) {
                DropDownList dropdown = (DropDownList)sender;
                String status = dropdown.SelectedValue.ToString();
                int id = Convert.ToInt32(dropdown.ID);
                UserController.updateUserStatus(id, status);
            }
        }
}