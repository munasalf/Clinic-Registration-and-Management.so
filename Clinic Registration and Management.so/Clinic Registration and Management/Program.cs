using Clinic_Registration_and_Management.ApplicationDBclinicDb;
using Clinic_Registration_and_Management.Migrations;
using Clinic_Registration_and_Management.Model;

namespace Clinic_Registration_and_Management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ApplicationDBClining _Datab = new ApplicationDBClining();
       
            Console.WriteLine("Welcome to the Clinic Registration and Management System!");

            int userWant;
            while (true)
            {
                do
                {
                    Console.WriteLine("\n1.Patients\n" +
                        "2.Admin\n" +
                        "3.Exit\n"
                        );
                    Console.Write("Enter Your choise:");
                } while (!int.TryParse(Console.ReadLine(), out userWant) && userWant != 3);

                if (userWant == 3) break;
                else if (userWant == 1)
                {
                    Patients Patientss = Patient_Details();
                    //_Datab.Patient.Add(Patients);
                    _Datab.patientss.Add(Patientss);


                    Book_appointment book_appointment = Determine_Appointment(Patientss , _Datab );
                    _Datab.book_appointment.Add(book_appointment);
                    _Datab.SaveChanges();
                    Console.WriteLine("Your Appointment has Registered\n\n\t An Email will be send for Confirmation.");
                }
                else if (userWant == 2)
                {
                    int userWanted;
                    do
                    {
                        Console.WriteLine("\n1.View Appointments \n" +
                            "2.View and set Status of Appointments\n"
                            );
                        Console.Write("Enter Your choise:");
                    } while (!int.TryParse(Console.ReadLine(), out userWanted) && (userWanted > 0 && userWanted < 3));

                    if (userWanted == 1) Just_View_Appointment(_Datab);
                    if (userWanted == 2) View_And_Set_Status_Appointment(_Datab);
                }




            }
            Console.WriteLine("\nThank you for using the Clinic Registration and Management System!");


        }

        public static Patients Patient_Details()
        {
            Console.Write("\n\nEnter Your full Name:");
            string fullname = Console.ReadLine();

            Console.Write("Enter Your Last Name:");
        

            int age;

            do
            {
                Console.Write("Enter Your Age:");

            } while (!int.TryParse(Console.ReadLine(), out age) && age >= 0);

            Console.Write("Enter Your Email:");
            string email = Console.ReadLine();

            Console.Write("Enter Your Phone:");
            long phone =long.Parse(Console.ReadLine());

            Patients patient = new Patients()
            {
                FullName = fullname,
                
                Age = age,
               
                PhoneNumber = phone
            };

            return patient;
        }

        public static Book_appointment Determine_Appointment(Patients Patientss, ApplicationDBClining _Datab)
        {
            Console.WriteLine("\n");
            var Spec = (from S in _Datab.specializations
                        select S).ToList();


            foreach (var item in Spec)
            {
                Console.Write((item?.SpecializationID ?? 0) + "  || ");
                Console.Write(item?.SpecializationName + "  ||  " ?? "NA  ||  ");
                Console.WriteLine(item?.Detiles ?? "NA");
                Console.WriteLine();
            }

            int Specialization;
            do
            {
                Console.Write("Where do you whant to treating:(1-4) ");
            } while (!int.TryParse(Console.ReadLine(), out Specialization) && Specialization > 0 && Specialization <= Spec.Count());

            Console.WriteLine("\nDetermine your Appointment:");

            Console.Write("Enter Day: Exp YYYY-MM-DD ");
            string AppointmentDate = Console.ReadLine();


            Console.Write("Enter Time: Exp HH:MI ");
            string AppointmentTime = Console.ReadLine();

            int Idcard = (from P in _Datab.patientss
                              where P.Description == Patientss.Description
                              select P.Idcard).FirstOrDefault();

            Book_appointment appointment = new Book_appointment()
            {
                Appointment_Date  = AppointmentDate,
                Appointment_Time = AppointmentTime,
                Appointment_Status = "pending",
                Idcard = Idcard,
                SpecializationID = Specialization
            };


            //set The patient
            appointment.Patient = Patientss;

            //set The Specialization
            var Specializationa = (from S in _Datab.specializations
                                   where S.SpecializationID == Specialization
                                   select S).FirstOrDefault();
            appointment.specializations = Specializationa;

            return appointment;



        }

        public static void Just_View_Appointment(ApplicationDBClining _Datab)
        {
            Console.WriteLine("\n");
            var Apo = (from A in _Datab.book_appointment
                       select A).ToList();


            foreach (var item1 in Apo)
            {
                Console.Write((item1?.AppointmentID ?? 0) + "  || ");
                Console.Write(item1?.Appointment_Date + "  ||  " ?? "NA  ||  ");
                Console.WriteLine(item1?.Appointment_Time ?? "NA  ||  ");
                Console.Write(item1?.Appointment_Status + "  ||  " ?? "NA  ||  ");
                Console.Write((item1?.Idcard ?? 0) + "  || ");
                Console.Write(item1?.Patient?.FullName + "  ||  " ?? "NA  ||  ");
                Console.Write(item1?.specializations?.SpecializationName + "  ||  " ?? "NA  ||  ");
                Console.WriteLine();


            }
        }
        public static void View_And_Set_Status_Appointment(ApplicationDBClining _Datab)
        {
            Console.WriteLine("\n");
            var Apo = (from A in _Datab.book_appointment
                       select A).ToList();


            foreach (var item2 in Apo)
            {
                Console.Write((item2?.AppointmentID ?? 0) + "  || ");
                Console.Write(item2?.Appointment_Date + "  ||  " ?? "NA  ||  ");
                Console.WriteLine(item2?.Appointment_Time ?? "NA  ||  ");
                Console.Write(item2?.Appointment_Status + "  ||  " ?? "NA  ||  ");
                Console.Write((item2?.Idcard ?? 0) + "  || ");
                Console.Write(item2?.Patient?.FullName + "  ||  " ?? "NA  ||  ");
                Console.Write(item2?.specializations?.SpecializationName + "  ||  " ?? "NA  ||  ");
                Console.WriteLine();

                Console.Write("Set the Status of the Appointment:( Approve, Reschedule, or Cancel )");
                string status = Console.ReadLine();
                if (status.ToLower() == "reschedule")
                {
                    Console.Write("Enter Day: Exp YYYY-MM-DD ");
                    string AppointmentDate = Console.ReadLine();

                    item2.Appointment_Date = AppointmentDate;

                    Console.Write("Enter Time: Exp HH:MI ");
                    string AppointmentTime = Console.ReadLine();

                    item2.Appointment_Time = AppointmentTime;
                    _Datab.SaveChanges();
                }
                item2.Appointment_Status = status;
                _Datab.book_appointment.Update(item2);
                _Datab.SaveChanges();
            }

            Console.Write("All Appointment Status are Seted!");

        }
    }
    
}