﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using MySql.Data;

namespace Arduino
{
    class Users
    {
        dbConnection db = new dbConnection();
        private string sql;
        private int rol;
        public int level;
        
        public bool logIn(string username, string password)
        {
            db.connect();
            sql = "SELECT * FROM users WHERE u_username='" + username + "' and u_password=MD5('" + password + "')";
            try{
                db.ExecuteReader(sql);
                if (db.getReader.HasRows && db.getReader.Read())
                {
                    level = db.getReader.GetInt32(4);
                    log_login(db.getReader.GetInt32(0), "OK");
                    return true;

                }
                else
                {
                    log_login(db.getReader.GetInt32(0), "BAD");
                    MessageBox.Show("Datos de acceso incorrectos.");
                    return false;
                }
                db.disconnect();
            }catch(Exception ex){
                MessageBox.Show("Ocurrio un error al realizar la petición, intente nuevamente.");
                return false;
            }
            
        }

        public void log_login(int id_user,string status)
        {
            DateTime now = DateTime.Now;
            db.connect();
            sql = "INSERT INTO log_login(id_user,status,date) values(" + id_user + ",'" + status + "','" + now.ToString("yyyy-MM-dd HH':'mm':'ss") + "')";
            try
            {
                db.executeSql(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(sql);
            }

        }

        public void getUsers(DataGridView gridUsers)
        {
            string rol;
            db.connect();
            sql = "SELECT u_id,u_name,u_username,u_level FROM users";
            try
            {
                db.ExecuteReader(sql);
                if (db.getReader.HasRows)
                {
                    
                    while (db.getReader.Read())
                    {
                        if (db.getReader.GetInt32(3) == 1) { rol = "Administrador"; } else { rol = "Usuario"; }
                        gridUsers.Rows.Add(db.getReader.GetInt32(0), db.getReader.GetString(1),db.getReader.GetString(2),rol);

                    }
                }
                db.disconnect();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error al obtener los datos, intente nuevamente.");
            }
        }

        public void addUser(string name,string username, string password, string level)
        {
            if(level == "Administrador") { rol = 1; }
            if (level == "Usuario") { rol = 2;  }
            db.connect();
            sql = "INSERT INTO users(u_name,u_username,u_password,u_level) values ('"+name+"','"+username+"',MD5('"+password+"'),"+rol+")";
            if (name != "" && username != "" && password != "" & level != "")
            {
                try
                {
                    db.executeSql(sql);
                    MessageBox.Show("Usuario agregado correctamente.");
                    
 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error, intente de nuevo.");
                }
            }
            else
            {
                MessageBox.Show("Es necesario llenar todos los datos, intente de nuevo.");
            }
            db.disconnect();
        }

        public void deleteUser(int id)
        {
            db.connect();
            sql = "DELETE FROM users WHERE u_id=" + id;
            try
            {
                db.executeSql(sql);
                MessageBox.Show("Usuario eliminado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error, intente de nuevo.");
            }
            db.disconnect();
        }

        public void editUser(int id, string name, string username, string level)
        {
            
            if(level == "Administrador") { rol = 1; }
            if (level == "Usuario") { rol = 2; }
            db.connect();
            sql = "UPDATE users SET u_name='" + name + "',u_username='" + username + "',u_level=" + rol+" WHERE u_id="+id;
            try
            {
                db.executeSql(sql);
                MessageBox.Show("Usuario actualizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error, intente de nuevo.");
            }
            db.disconnect();

        }


        public void getLogs(DataGridView gridLogs)
        {
            string rol;
            db.connect();
            sql = "select t1.u_name,t2.status,t2.date from (select * from users) as t1 join (select * from log_login) as t2 on t1.u_id=t2.id_user";
            try
            {
                db.ExecuteReader(sql);
                if (db.getReader.HasRows)
                {

                    while (db.getReader.Read())
                    {
                        gridLogs.Rows.Add(db.getReader.GetString(0), db.getReader.GetString(1), db.getReader.GetString(2));

                    }
                }
                db.disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al obtener los datos, intente nuevamente.");
            }
        }
    }
}
