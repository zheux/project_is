using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GCRS.Domain;

namespace GCRS.Data
{
    public static class UserManager
    {
        public static bool AddClient(Cliente client)
        {
            return true;
        }

        public static bool AddAgent(Agente agent)
        {
            return true;
        }

        public static bool AddAdmin(Admin admin)
        {
            return true;
        }

        public static Cliente FindClient(Cliente client)
        {
            return null;
        }

        public static Agente FindAgent(Agente agent)
        {
            return null;
        }

        public static Admin FindAdmin(Admin admin)
        {
            return null;
        }

        public static void RemoveUser(string username)
        {

        }
    }
}