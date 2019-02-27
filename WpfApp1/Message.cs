using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Message
{
    public int id;
    public string username;
    public string password;
    public string role;

    public string ToString => (id + " " + username + " " + password + " " + role);
}

