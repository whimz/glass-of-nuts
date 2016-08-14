using System;
using System.Collections;
using System.Reflection;

using ht_04_Add;
using ht_04_Student;
using ht_04_Group;


namespace ht_04_Add
{
    class FullName
    {
        public string name;
        public string middleName;
        public string surname;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                {
                    name = value;
                }
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                if (value != null)
                {
                    middleName = value;
                }
            }
        }
        
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value != null)
                {
                    surname = value;
                }
            }
        }
        public FullName(string name, string middleName, string surname)
        {
            SetName(name);
            SetMiddleName(middleName);
            SetSurname(surname);
        }
        public void SetName(string name)
        {
            if (name.Length != 0)
            {
                this.name = name;
            }
        }

        public void SetMiddleName(string middleName)
        {
            if (name.Length != 0)
            {
                this.middleName = middleName;
            }
        }

        public void SetSurname(string surname)
        {
            if (name.Length != 0)
            {
                this.surname = surname;
            }
        }

        public string GetName()
        {
            return name;
        }

        public string GetMiddleName()
        {
            return middleName;
        }

        public string GetSurname()
        {
            return surname;
        }
    }

    class Address
    {
        public string city;
        public string district;
        public string street;
        public string building;
        public string apartment;

        public Address(string city, string district, string street, string building, string apartment)
        {
            SetCity(city);
            SetDistrict(district);
            SetStreet(street);
            SetBuilding(building);
            SetApartment(apartment);
        }

        public void SetCity(string city)
        {
            if (city.Length != 0)
            {
                this.city = city;
            }

        }

        public void SetDistrict(string district)
        {
            if (district.Length != 0)
            {
                this.district = district;
            }
        }

        public void SetStreet(string street)
        {
            if (street.Length != 0)
            {
                this.street = street;
            }
        }

        public void SetBuilding(string building)
        {
            if (building.Length != 0)
            {
                this.building = building;
            }
        }

        public void SetApartment(string apartment)
        {
            if (apartment.Length != 0)
            {
                this.apartment = apartment;
            }
        }

        public string GetCity()
        {
            return city;
        }

        public string GetDistrict()
        {
            return district;
        }

        public string GetStreet()
        {
            return street;
        }

        public string GetBuilding()
        {
            return building;
        }

        public string GetApartment()
        {
            return apartment;
        }
    }
}


namespace ht_04_Student
{
    class Student : IComparable
    {
        public FullName fullName;
        private Address address;
        private DateTime birthDate;
        private string phoneNumber;
        private uint subjQuantity;
        private string[] subjects;
        private uint[] credits;//зачеты 
        private uint[] termWork;//курсовые
        private uint[] exams;// экзамены

        
        public Student() { }

        public Student(FullName fullName, Address address, DateTime birthDate)
        {
            SetFullName(fullName);
            SetAddress(address);
            SetBirthdate(birthDate);
        }

        public Student(FullName fullName, Address address, DateTime birthDate, string phoneNumber)
        {
            SetFullName(fullName);
            SetAddress(address);
            SetBirthdate(birthDate);
            SetPhoneNumber(phoneNumber);
        }

        public Student(FullName fullName, Address address, DateTime birthDate, string phoneNumber, uint subjQuantity)
        {
            SetFullName(fullName);
            SetAddress(address);
            SetBirthdate(birthDate);
            SetPhoneNumber(phoneNumber);
            SetSubjectsQuantity(subjQuantity);

            subjects = new string[subjQuantity];
            credits = new uint[subjQuantity];
            termWork = new uint[subjQuantity];
            exams = new uint[subjQuantity];

        }
        
        public void SetFullName(FullName fullName)
        {
            this.fullName = fullName;
        }

        public FullName GetFullName()
        {
            return fullName;
        }

        public void SetAddress(Address address)
        {
            this.address = address;
        }

        public Address GetAddress()
        {
            return address;
        }

        public void SetBirthdate(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }

        public DateTime GetBirthDate()
        {
            return birthDate;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 0)
            {
                this.phoneNumber = phoneNumber;
            }
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public void SetSubjectsQuantity(uint subjQuantity)
        {
            this.subjQuantity = subjQuantity;
            subjects = new string[subjQuantity];
            credits = new uint[subjQuantity];
            termWork = new uint[subjQuantity];
            exams = new uint[subjQuantity];

        }

        public uint GetSubjectsQuantity()
        {
            return subjQuantity;
        }

        public void SetSubjectName(uint index, string subjName)
        {
            if (index >= 0 && index < subjects.Length)
            {
                subjects[index] = subjName;
            }
        }

        public string GetSubjectName(uint index)
        {
            if (index >= 0 && index < subjects.Length)
            {
                return subjects[index];
            }
            else
            {
                return "Неверный индекс предмета";
            }
        }

        public void SetCreditMark(string subjName, uint mark)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == subjName)
                {
                    credits[i] = mark;
                    break;
                }
            }
        }

        public uint GetCreditMark(string subjName)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == subjName)
                {
                    return credits[i];
                }
            }
            return 0;
        }

        public void SetTermWorkMark(string subjName, uint mark)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == subjName)
                {
                    termWork[i] = mark;
                    break;
                }
            }
        }

        public uint GetTermWorkMark(string subjName)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == subjName)
                {
                    return termWork[i];
                }
            }
            return 0;
        }

        public void SetExamMark(string subjName, uint mark)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == subjName)
                {
                    exams[i] = mark;
                    break;
                }
            }
        }

        public uint GetExamMark(string subjName)
        {
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i] == subjName)
                {
                    return exams[i];
                }
            }
            return 0;
        }

        private double AverageMark()
        {
            double avgMark = 0;

            for (int i = 0; i < credits.Length; i++)
            {
                avgMark += Convert.ToDouble(credits[i] + termWork[i] + exams[i]) / Convert.ToDouble(credits.Length);
            }

            return avgMark;
        }

        public void ShowInfo()
        {
            Console.WriteLine("{0} {1} {2}",
                fullName.surname, fullName.name, fullName.middleName);

            Console.WriteLine("Дата рождения: {0}:{1}:{2}",
                birthDate.Day, birthDate.Month, birthDate.Year);

            //Console.WriteLine("г. {0}, {1} район, улица {2}, дом {3}, кв. {4}",
            //    address.city, address.district, address.street, address.building, address.apartment);

            Console.WriteLine("Телефон {0}", phoneNumber);

            Console.WriteLine("Предметы: \tЗачеты \tКурсовые \tЭкзамены");
            Console.WriteLine("------------------------------------------------");

            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t\t{3}", subjects[i], credits[i], termWork[i], exams[i]);
            }

            Console.WriteLine("=================================================");

        }

        public override string ToString()
        {
            return "ФИО:\t\t" + fullName.Surname + " " + fullName.Name + " " + fullName.MiddleName +
                "\nДата рождения:\t" + birthDate.Day + "." + birthDate.Month + "." + birthDate.Year +
                "\nТелефон:\t" + phoneNumber + "\n" + 
                "-------------------------------------------------\n";
        }


        //-------------IComparable----------------------------------------------------------------
        public int CompareTo(object obj)
        {
            Student s = obj as Student;

            if (this.AverageMark() > s.AverageMark()) return 1;
            if (this.AverageMark() < s.AverageMark()) return -1;
            return 0;

        }

        //-------------IComparer classes----------------------------------------------------------
        public class SortByRate : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Student s1 = (Student)x;
                Student s2 = (Student)y;

                return (s1.AverageMark() == s2.AverageMark()) ? 0 : (s1.AverageMark() > s2.AverageMark()) ? 1 : -1;
            }
        }

        public class SortBySurnameAZ : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Student s1 = (Student)x;
                Student s2 = (Student)y;

                return (s1.fullName.Surname.CompareTo(s2.fullName.Surname) == 0) ? 0 : (s1.fullName.Surname.CompareTo(s2.fullName.Surname) > 0) ? 1 : -1;
            }
        }

        public class SortBySurnameZA : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Student s1 = (Student)x;
                Student s2 = (Student)y;

                return (s1.fullName.Surname.CompareTo(s2.fullName.Surname) == 0) ? 0 : (s1.fullName.Surname.CompareTo(s2.fullName.Surname) > 0) ? -1 : 1;
            }
        }

        public class SortByAge : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Student s1 = (Student)x;
                Student s2 = (Student)y;

                return (s1.birthDate.CompareTo(s2.birthDate) == 0) ? 0 : (s1.birthDate.CompareTo(s2.birthDate) > 0) ? 1 : -1;
            }
        }

        //---------интерфейс IEnumerable для класса Student-----------------------------------
        private string[] GetStudentObjectParams()
        {   
            Type t = typeof(Student);
            
            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo[] fi = t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            PropertyInfo[] pri = t.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            string[] objParams = new string[mi.Length + fi.Length + pri.Length];

            int index = 0;

            foreach (var item in mi)
            {
                objParams[index] = item.ReturnType.Name + " " + item.Name + "(";
                ParameterInfo[] pi = item.GetParameters();
                if (pi.Length != 0)
                {
                    for (int i = 0; i < pi.Length; i++)
                    {
                        objParams[index] += pi[i].ParameterType + " " + pi[i].Name;
                        if (i + 1 < pi.Length)
                        {
                            objParams[index] += ", ";
                        }
                    }
                    objParams[index] += ")";
                }
                else
                    objParams[index] += ")";

                ++index;
            }



            foreach (var item in fi)
            {
                objParams[index] = item.Name + " = " + item.GetValue(this);
                ++index;
            }


            if (pri.Length != 0)
            {
                foreach (var item in pri)
                {
                    objParams[index] = item.Name + " = " + item.GetValue(this);
                    ++index;
                }
            }
                                   
            return objParams;
        }

        public StudentEnumerator GetEnumerator()
        {
            return new StudentEnumerator(GetStudentObjectParams());
        }
        
    }

    class StudentEnumerator
    {
        public string Current { get; private set; }

        private int step;
        private string[] objParams;

        public StudentEnumerator(string[] objParams)
        {
            this.objParams = objParams;
        }

        public bool MoveNext()
        {
            if (step >= objParams.Length) return false;
            Current = objParams[step++];
            return true;
        }
    }

}


namespace ht_04_Group
{

    class Group
    {
        private Student[] group;
        private uint stQuantity;
        private string grName;
        private string speciality;
        private uint courseNumber;

        private static string[] specs = "Программирование ПрикладнаяМатематика Сети".Split();
        private static string[] surnames = "Бутько Вейдер Гойко Гречко Рабинович Гришко Данилко Лучко Пяточкин Лазирко Кличко Осадко Сирко Сушко Цушко Скоропадський Коцюбинський Латанський Бдыщь Лобачевський Милославський Глинський Ковальський".Split();
        private static string[] middleNames = "Адольфович Петрович Бруневич Копатыч Лопатыч Арсениевич Дуваныч Могарыч Флинтович Ольгович Алексеевич Венедиктович Горлумович Карпович".Split();
        private static string[] names = "Дарт Арнольд Бэтмен Жан-Клод Бен-Аффлек Захарас Жырик Жорик Фрол Егор Гордон-Фримен Спайдермен Карлсон Котейка Фома Хесус Аполлон Поликарп".Split();
        private static Random rnd = new Random();

        public Group()
        {
            stQuantity = 10;
            GenerateGroup(stQuantity);
        }

        public Group(uint stQuantity)
        {
            SetStudentsQuantity(stQuantity);
            group = new Student[this.stQuantity - 1];
        }

        public Group(Student[] currentStudents)
        {
            Student[] newGroup = new Student[currentStudents.Length];
            Array.Copy(currentStudents, newGroup, currentStudents.Length);
        }

        public Group(Group currentGroup)
        {
            Student[] newGroup = new Student[currentGroup.group.Length];
            Array.Copy(currentGroup.group, newGroup, currentGroup.group.Length);

            stQuantity = currentGroup.GetStudentsQuantity();
            grName = currentGroup.GetGroupName();
            speciality = currentGroup.GetSpeciality();
            courseNumber = currentGroup.GetCourseNumber();
        }

        public string GrName
        {
            get
            {
                return grName;
            }
            set
            {
                if (value != null)
                {
                    grName = value;
                }
            }
        }

        public string Speciality
        {
            get
            {
                return speciality;
            }
            set
            {
                if (value != null)
                {
                    grName = value;
                }
            }
        }

        public uint CourseNumber
        {
            get
            {
                return courseNumber;
            }
            set
            {
                if (value.GetTypeCode() == TypeCode.UInt16 && value >= 1 && value <= 5)
                {
                    courseNumber = value;
                }
            }
        }
        public Student GetStudent(int index)
        {
            --index;
            if (index >= 0 && index < group.Length)
            {
                return group[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Неправильный параметр - номер студента");
            }

        }

        private void GenerateGroup(uint stQuantity)
        {
            speciality = specs[rnd.Next(0, 2)];

            grName = (rnd.Next(100, 300)).ToString();

            courseNumber = Convert.ToUInt16(rnd.Next(1, 5));

            group = new Student[stQuantity];

            for (uint i = 0; i < group.Length; i++)
            {
                group[i] = new Student();

                group[i].SetSubjectsQuantity(5);
                group[i].SetFullName(new FullName(names[rnd.Next(0, names.Length - 1)],
                    middleNames[rnd.Next(0, middleNames.Length - 1)],
                    surnames[rnd.Next(0, surnames.Length - 1)]));

                group[i].SetBirthdate(new DateTime(rnd.Next(1990, 1999), rnd.Next(1, 12), rnd.Next(1, 30)));

                group[i].SetPhoneNumber("+38(0" + (rnd.Next(66, 99)).ToString() + ")" + (rnd.Next(100, 999)).ToString() + "-"
                    + (rnd.Next(10, 99)).ToString() + "-" + (rnd.Next(10, 99)).ToString());

                //забиваем предметы и оценки
                for (uint j = 0; j < group[i].GetSubjectsQuantity(); j++)
                {
                    group[i].SetSubjectName(j, "Предмет " + (j + 1).ToString());
                    group[i].SetCreditMark(group[i].GetSubjectName(j), Convert.ToUInt16(rnd.Next(1, 12)));
                    group[i].SetExamMark(group[i].GetSubjectName(j), Convert.ToUInt16(rnd.Next(1, 12)));
                    group[i].SetTermWorkMark(group[i].GetSubjectName(j), Convert.ToUInt16(rnd.Next(1, 12)));
                }
            }
        }

        public Student[] GetStudents()
        {
            Student[] st = new Student[group.Length];

            Array.Copy(group, st, group.Length);

            return st;
        }

        public void SetStudentsQuantity(uint stQuantity)
        {
            if (stQuantity.GetTypeCode() == TypeCode.UInt16)
            {
                this.stQuantity = stQuantity;
            }
            else
            {
                Console.WriteLine("Неверный параметр - количество студентов в группе");
            }
        }

        public uint GetStudentsQuantity()
        {
            return stQuantity;
        }

        public void SetGroupName(string grName)
        {
            if (grName.GetTypeCode() == TypeCode.String && grName != null)
            {
                this.grName = grName;
            }
            else
            {
                Console.WriteLine("Неверный параметр названия группы");
            }
        }

        public string GetGroupName()
        {
            return grName;
        }

        public void SetSpeciality(string speciality)
        {
            if (speciality.GetTypeCode() == TypeCode.String && speciality != null)
            {
                this.speciality = speciality;
            }
            else
            {
                Console.WriteLine("Неверный параметр названия специальности");
            }
        }

        public string GetSpeciality()
        {
            return speciality;
        }

        public void SetCourseNumber(uint courseNumber)
        {
            if (courseNumber.GetTypeCode() == TypeCode.UInt16)
            {
                this.courseNumber = courseNumber;
            }
            else
            {
                Console.WriteLine("Неверный параметр - номер курса");
            }
        }

        public uint GetCourseNumber()
        {
            return courseNumber;
        }

        public void AddStudent(Student newStudent)
        {
            Array.Resize(ref group, group.Length + 1);
            group[group.Length - 1] = newStudent;
            ++stQuantity;
        }

        public void RemoveStudent(uint index)
        {
            Student[] st = new Student[group.Length];

            if (index.GetTypeCode() == TypeCode.UInt16 && (index >= 1 && index <= group.Length))
            {
                if (--index == 0)
                {
                    for (int i = 1; i < group.Length; i++)
                    {
                        st[i - 1] = group[i];
                    }
                }
                else
                {
                    for (int i = 0; i < index; i++)
                    {
                        st[i] = group[i];
                    }

                    for (int i = Convert.ToUInt16(index + 1); i < group.Length; i++)
                    {
                        st[i - 1] = group[i];
                    }
                }

                group = st;
                --stQuantity;
            }
            else
            {
                Console.WriteLine("Неверный параметр - номер студента");
            }
        }

        public void TransferStudent(Group destination, uint index)
        {
            if (index.GetTypeCode() == TypeCode.UInt16 && (index >= 1 && index <= group.Length))
            {
                destination.AddStudent(group[--index]);
                RemoveStudent(index);
            }

        }

        public void ExpellExamFailers()
        {
            Student[] st = new Student[1];
            int ctr = 0;

            for (int i = 0; i < group.Length; i++)
            {
                for (int j = 0; j < group[i].GetSubjectsQuantity() - 1; j++)
                {
                    if (group[i].GetCreditMark(group[i].GetSubjectName(Convert.ToUInt16(j))) <= 3 &&
                        group[i].GetExamMark(group[i].GetSubjectName(Convert.ToUInt16(j))) <= 3)
                    {
                        continue;
                    }
                    else
                    {
                        st[ctr++] = group[i];
                        Array.Resize(ref st, st.Length + 1);
                    }
                }
            }

            if (ctr != 0)
            {
                group = st;
            }
        }

        public void ExpelWithMinMarks()
        {
            int index = 0;
            uint minMark = 12;
            for (int i = 0; i < group.Length; i++)
            {

                for (int j = 0; j < group[i].GetSubjectsQuantity() - 1; j++)
                {
                    if (group[i].GetCreditMark(group[i].GetSubjectName(Convert.ToUInt16(j))) +
                        group[i].GetExamMark(group[i].GetSubjectName(Convert.ToUInt16(j))) +
                        group[i].GetTermWorkMark(group[i].GetSubjectName(Convert.ToUInt16(j))) < minMark)
                    {
                        minMark = group[i].GetCreditMark(group[i].GetSubjectName(Convert.ToUInt16(j))) +
                        group[i].GetExamMark(group[i].GetSubjectName(Convert.ToUInt16(j))) +
                        group[i].GetTermWorkMark(group[i].GetSubjectName(Convert.ToUInt16(j)));

                        index = i;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            if (index != 0)
            {
                RemoveStudent(Convert.ToUInt16(++index));
            }
            else
            {
                Console.WriteLine("Все ребята - молодцы.");
            }
        }

        public void ShowGroupInfo()
        {
            Console.WriteLine("Группа № {0}, {1} курс, специальность {2}", GetGroupName(), GetCourseNumber(), GetSpeciality());
            Console.WriteLine();
            // Array.Sort(group, (s1, s2) => s1.GetFullName().surname.CompareTo(s2.GetFullName().surname));

            for (int i = 0; i < group.Length; i++)
            {
                Console.Write("{0}: ", i + 1);
                group[i].ShowInfo();
            }
        }

        
        public void Edit()
        {
            Console.WriteLine("Редактировать данные группы:");
            Console.WriteLine("Изменить: ");
            Console.WriteLine("\tНазвание - 1\n\tСпециальность - 2\n\tКурс - 3\n\tДанные студента - 4");

            uint option = Convert.ToUInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Введите новое название группы");
                    grName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Введите новое название специальности");
                    speciality = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Введите новый номер курса");
                    courseNumber = Convert.ToUInt16(Console.ReadLine());
                    break;
                case 4:

                    Console.WriteLine("Введите номер студента");
                    uint index = (Convert.ToUInt16(Console.ReadLine())) - 1U;

                    Console.WriteLine("Редактировать данные студента:");
                    Console.WriteLine("Изменить:");
                    Console.WriteLine("\tФИО - 1\n\tАдрес - 2\n\tДата рождения - 3\n\tНомер телефона - 3\n\tОценки - 4");

                    option = Convert.ToUInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Введите ФИО");
                            group[index].SetFullName(new FullName(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Введите адрес");
                            group[index].SetAddress(new Address(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
                            break;
                        case 3:
                            Console.WriteLine("Введите номер телефона");
                            group[index].SetPhoneNumber(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Редактировать оценки:");
                            Console.WriteLine("Изменить:");
                            Console.WriteLine("\tЗачеты - 1\n\tКурсовые - 2\n\tЭкзамен - 3");

                            option = Convert.ToUInt32(Console.ReadLine());

                            string subj;
                            uint mark;
                            switch (option)
                            {
                                case 1:
                                    Console.WriteLine("Введите предмет:");
                                    subj = Console.ReadLine();
                                    Console.WriteLine("Введите оценку");
                                    mark = Convert.ToUInt16(Console.ReadLine());
                                    group[index].SetCreditMark(subj, mark);
                                    break;
                                case 2:
                                    Console.WriteLine("Введите предмет:");
                                    subj = Console.ReadLine();
                                    Console.WriteLine("Введите оценку");
                                    mark = Convert.ToUInt16(Console.ReadLine());
                                    group[index].SetTermWorkMark(subj, mark);
                                    break;
                                case 3:
                                    Console.WriteLine("Введите предмет:");
                                    subj = Console.ReadLine();
                                    Console.WriteLine("Введите оценку");
                                    mark = Convert.ToUInt16(Console.ReadLine());
                                    group[index].SetExamMark(subj, mark);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        //---------метод Sort для сортировки по заданному критерию
        public void SortBySurnameAZ()
        {
            Array.Sort(group, new Student.SortBySurnameAZ());
        }

        public void SortBySurnameZA()
        {
            Array.Sort(group, new Student.SortBySurnameZA());
        }

        public void SortByAge()
        {
            Array.Sort(group, new Student.SortByAge());
        }

        public void SortByRate()
        {
            Array.Sort(group, new Student.SortByRate());
        }

        //------метод печати группы Print, используя конструкцию foreach.
        public void Print()
        {
            foreach (var item in group)
            {
                Console.Write(item);
            }
        }

        //------метод Search для поиска студента по заданному критерию
        public void SearchByYearOfBirth(int year)
        {
            foreach (var item in group)
            {
                if (year == item.GetBirthDate().Year)
                {
                    Console.Write(item);
                }
            }
        }
       
    }
        
}


namespace _05_1_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            //----client code for Student : IComparable implementation view

            //Group gr = new Group();
            //Student[] st = new Student[gr.GetStudentsQuantity()];
            //st = gr.GetStudents();
            //Array.Sort(st);

            //foreach (var item in st)
            //{
            //    item.ShowInfo();
            //}


            //----client code for Student ICompare implementation view

            //gr.SortBySurnameZA();
            //gr.ShowGroupInfo();
            //gr.SortByAge();
            //gr.ShowGroupInfo();
            //gr.SortByRate();
            //gr.ShowGroupInfo();


            //----client code for Group IEnumerable implementation view

            //gr.Print();
            //gr.SearchByYearOfBirth(1994);


            //----client code for Student IEnumerable implementation view

            //Student s = new Student();

            //foreach (var item in s)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }
}


