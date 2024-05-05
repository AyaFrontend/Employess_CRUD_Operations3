using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_CRUD_Operations.ConnectionData
{
    public static class ServerConnectionData
    {
        public static string ConnectionString { get; } = "Server= PC\\SQLEXPRESS; Database = Employees_CRUD_Operations ; Integrated Security = true ";
        public static string Redis { get; } = "localhost";
    }
}
