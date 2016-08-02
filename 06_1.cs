//-------------------------------------------------------------------
//создать класс-коллекцию логинов и паролей.+++
//сделать в классе свойство Count.+++
//
//реализовать возможности:
//- просмотра существующих логинов,+++
//- добавления нового пользователя,+++
//- удаления пользователя по логину,+++
//- редактирования пользователя по логину.+++
//
//пароли хранить в зашифрованном виде (например, применить XOR).+++
//
//для тестирования возможностей класса реализовать меню.+++
//
//применить индексаторы (например, при просмотре пользователей).+++  
//---------------------------------------------------------------------


using System;
using System.Linq;


class LoginPassword
{
    private String login;
    private String password;
    
    public LoginPassword(String login, String password)
    {
        this.login = login;
        this.password = password;        
    }

    public String Login
    {
        get
        {
            return login;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                login = value;
            }
        }
    }

    public String Password
    {
        get { return password; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                password = value;
            }
        }
    }
        
    public override String ToString()
    {
        return login;
    }
}

class Users
{
    private LoginPassword[] loginPassword;
    private Int32 count = 0;
    private const Int32 usersInc = 10;

    public Users(Int32 size = usersInc)
    {
        loginPassword = new LoginPassword[size];
    }

    public void SetCount()
    {
        count++;
    }

    public Int32 Length
    {
        get
        {
            return loginPassword.Length;
        }
    }

    public Int32 Count
    {
        get
        {
            return count;
        }
    }

    public LoginPassword this[Int32 index]
    {
        get
        {
            if (index < 0 || index >= loginPassword.Length)
            {
                throw new IndexOutOfRangeException("Account ID is out of range");
            }
            else
            {
                return loginPassword[index];
            }
        }
        set
        {
            loginPassword[index] = value;
        }
    }

    public LoginPassword this[String login]
    {
        get
        {
            if (login.Length == 0 || FindByLogin(login) == -1)
            {
                throw new IndexOutOfRangeException("No login found");
            }
            else
            {
                return this[FindByLogin(login)];
            }
        }
    }

    private Int32 FindByLogin(String login)
    {
        Int32 result = -1;

        for (Int32 i = 0; i < loginPassword.Length; i++)
        {
            if (loginPassword[i].Login == login)
            {
                result = i;
                break;
            }
        }

        return result;
    }

    public void AddUser()
    {
        Console.WriteLine("Введите логин нового пользователя");
        String lgn = Console.ReadLine();
        Console.WriteLine("Введите пароль");
        String psswrd = Console.ReadLine();
        psswrd = new String(psswrd.Select(c => (char)(c ^ 42)).ToArray());

        LoginPassword lp = new LoginPassword(lgn, psswrd);
        count++;

        if (loginPassword.Length <= count)
        {
            IncreaseSize();
        }

        for (int i = 0; i < loginPassword.Length; i++)
        {
            if (loginPassword[i] == null)
            {
                loginPassword[i] = lp;
                break;
            }
                
        }        
    }

    public void DeleteUser()
    {
        Console.WriteLine("Введите логин аккаунта для удаления");
        String lgn = Console.ReadLine();
        Console.WriteLine("Введите пароль для подтверждения");
        String psswrd = Console.ReadLine();

        String decoded = new String((loginPassword[FindByLogin(lgn)].Password).Select(c => (char)(c ^ 42)).ToArray());
        
        if (psswrd.Equals(decoded))
        {
            loginPassword[FindByLogin(lgn)] = null;
            count--;
        }
                
    }

    public void EditUser()
    {
        Console.WriteLine("Введите логин аккаунта для редактирования");
        String lgn = Console.ReadLine();

        Console.WriteLine("Изменить:\n\tЛогин:\t\t1\n\tПароль:\t\t2\n\tОба варианта:\t3");

        Int32 option = Convert.ToInt32(Console.ReadLine());
        Int32 editIndex = FindByLogin(lgn);
        String psswrd;
        Console.WriteLine(editIndex);

        switch (option)
        {
            case 1://изменить логин
                Console.WriteLine("Введите новый логин"); 
                loginPassword[editIndex].Login = Console.ReadLine();
                break;
            case 2://изменить пароль
                Console.WriteLine("Введите старый пароль");
                psswrd = Console.ReadLine();

                String decoded = new String((loginPassword[FindByLogin(lgn)].Password).Select(c => (char)(c ^ 42)).ToArray());

                if (psswrd.Equals(decoded))
                {
                    Console.WriteLine("Введите новый пароль");
                    psswrd = Console.ReadLine();
                    loginPassword[editIndex].Password = new String(psswrd.Select(c => (char)(c ^ 42)).ToArray());
                }
                                
                break;
            case 3://изменить логин и пароль
                Console.WriteLine("Введите старый пароль");
                psswrd = Console.ReadLine();

                decoded = new String((loginPassword[FindByLogin(lgn)].Password).Select(c => (char)(c ^ 42)).ToArray());

                if (psswrd.Equals(decoded))
                {
                    Console.WriteLine("Введите новый логин");
                    loginPassword[editIndex].Login = Console.ReadLine();
                    Console.WriteLine("Введите новый пароль");
                    psswrd = Console.ReadLine();
                    loginPassword[editIndex].Password = new String(psswrd.Select(c => (char)(c ^ 42)).ToArray());
                }

                break;
            default:
                Console.WriteLine("Некорректная опция");
                break;
        }

    }

    public void IncreaseSize()
    {
        Array.Resize(ref loginPassword, loginPassword.Length + usersInc);
    }

    public void ViewLogins()
    {
        foreach (LoginPassword user in loginPassword)
        {
            if (user == null)
            {
                continue;
            }
            Console.WriteLine("{0}", user.Login);
        }
    }
}

namespace indexers
{
    class Program 
    {
        static void Main(string[] args)
        {
            Users u = new Users();

            //тестовые 10 юзеров. 
            //логин------------пароль
            //user0 ---------- password0
            //..........................
            //user9 ---------- password9
            for (Int32 i = 0; i < u.Length; i++)
            {
                u[i] = new LoginPassword(("user" + i.ToString()), ("password" + i.ToString()));
                u[i].Password = new String(u[i].Password.Select(c => (char)(c ^ 42)).ToArray());
                u.SetCount();
            }

            Int32 option = 1;

            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("\tПросмотр существующих логинов:......(1)");
                Console.WriteLine("\tДобавление нового пользователя:.....(2)");
                Console.WriteLine("\tУдаление пользователя:..............(3)");
                Console.WriteLine("\tРедактирование пользователя:........(4)");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        u.ViewLogins();
                        break;
                    case 2:
                        u.AddUser();
                        u.ViewLogins();
                        break;
                    case 3:
                        u.DeleteUser();
                        u.ViewLogins();
                        break;
                    case 4:
                        u.EditUser();
                        u.ViewLogins();
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Продолжить работу? (1 -> Да)");
                option = Convert.ToInt32(Console.ReadLine());

            } while (option == 1);           

        }
        
    }
}
