using CMS.Data.Entities;

namespace CMS.Data.Services
{
    public static class Seeder
    {
        // use this class to seed the database with dummy test data using an IUserService 
        public static void Seed(IPatientService svc)
        {
            // seeder destroys and recreates the database - NOT to be called in production!!!
            svc.Initialise();

            // add admin users
            var admin = svc.AddUser(
                new User
                {
                    Firstname = "The",
                    Surname = "Admin",
                    Password = "password",
                    Email = "admin@mail.com",
                    Role = Role.admin
                }
            );

            var manager = svc.AddUser(
                new User
                {
                    Firstname = "The",
                    Surname = "Manager",
                    Email = "manager@mail.com",
                    Password = "password",
                    Role = Role.manager
                }
            );


            // ===================  add carers ==================

            var c1 = svc.AddCarer(new User
            {
                Title = "Mr",
                Firstname = "Carer",
                Surname = "One",
                DOB = new DateTime(1977, 05, 28),
                NationalInsuranceNo = "NR456123D",
                DBSCheck = true,
                Email = "carer1@mail.com",
                Password = "password",
                Street = "34 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Qualifications = "8 GCSE's, Maths, A, English B, Social Care A, Accounts C,Economics C Art B, RE C, PSE C",
                PhotoUrl = "/images/Carer1.jpg",
                Role = Role.manager

            });

            var c2 = svc.AddCarer(new User
            {
                Title = "Mrs",
                Firstname = "Mary",
                Surname = "Hegarty",
                DOB = new DateTime(1977, 06, 28),
                NationalInsuranceNo = "NR561234D",
                DBSCheck = true,
                Email = "carer2@mail.com",
                Password = "password",
                Street = "34 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Qualifications = "8 GCSE's, Maths, A, English B, Social Care A, Accounts C,Economics C Art B, RE C, PSE C",
                PhotoUrl = "/images/Carer2.jpg",
                Role = Role.carer

            });

            var c3 = svc.AddCarer(new User
            {
                Title = "Mrs",
                Firstname = "Mary",
                Surname = "Hasselhoff",
                DOB = new DateTime(1965, 06, 30),
                NationalInsuranceNo = "NR612345D",
                DBSCheck = true,
                Email = "carer3H@mail.com",
                Password = "password",
                Street = "35 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Qualifications = "8 GCSE's, Maths, A, English B, Social Care A, Accounts C,Economics C Art B, RE C, PSE C",
                PhotoUrl = "/images/Carer3.jpg",
                Role = Role.carer
            });
            var c4 = svc.AddCarer(new User
            {
                Title = "Mrs",
                Firstname = "Amanda",
                Surname = "Hasselhoff",
                DOB = new DateTime(1970, 06, 30),
                NationalInsuranceNo = "NR3212432D",
                DBSCheck = true,
                Email = "carer4@mail.com",
                Password = "password",
                Street = "37 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                MobileNumber = "00112233456",
                HomeNumber = "02830303030",
                Qualifications = "8 GCSE's, Maths, A, English B, Social Care A, Accounts C,Economics C Art B, RE C, PSE C",
                PhotoUrl = "/images/carer4.jpg",
                Role = Role.carer
            });



            // =====    add patient data  ==============
            var p1 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "Joe",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR12345C",
                DOB = new DateTime(1945, 03, 03),
                Street = "24 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/1.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "joe@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Joe is an elderly gentleman who lives on his own.  " +
                "He needs help with most things, " + "Medication, dressing, breakfast, lunch, dinner.  " +
                "He suffers from incontinence and needs to be changed regularly.  "

                //  ....
            });

            var p2 = svc.AddPatient(new Patient
            {
                Title = "Mrs",
                Firstname = "Mary",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR23456C",
                DOB = new DateTime(1946, 02, 04),
                Street = "25 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/2.jpg",
                MobileNumber = "01234567892",
                HomeNumber = "02830303031",
                Email = "Mary@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Mary is an elderly woman who lives on her own.  " +
                "She needs help with most things.  " + "Medication, dressing, breakfast, lunch, dinner, changing tv channels.  " +
                "Please ensure her medication is given on time.  "
                // ....
            });


            var p3 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "Tom",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR34567C",
                DOB = new DateTime(1947, 05, 28),
                Street = "26 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/3.jpg",
                MobileNumber = "01234567892",
                HomeNumber = "02830303031",
                Email = "Tom@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Tom a former bank manager, has problems with his hands and finds it very difficult to dress.  "
                + "He finds it difficult to use the tv remote, he is suffering from dementia, but has many friends that call.  " +
                "He is a very proud man who especially likes to be dressed right.  He needs help with putting on washes, and transferring clothes" +
                " to the tumble drier."
                // ....
            });


            var p4 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "Donald",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR45678C",
                DOB = new DateTime(1948, 05, 28),
                Street = "27 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/4.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "Donald@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Donald used to work in the tv industry and loves chatting.  He is very immobile.  " +
                "He needs help with medication, washing and dressing.  " + "Donald has lost a substantial amount of weight after a recent operation.  " +
                 "He needs reminding to eat.  Please ensure that he eats.  There is always plenty of food in the fridge.  " +
                 "The family are very concerned about him at the moment."
                // ....
            });


            var p5 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "Mickey",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR56789C",
                DOB = new DateTime(1947, 05, 28),
                Street = "28 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/5.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "Mickey@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Mickey loves to laugh.  Mickey has some mobility issues but can dress himself.  " +
                "He needs help with his medication.  He also has some memory problems, his wife who was a doctor, died recently.  " +
                "That has had an effect on him.  He needs help with washing, putting on the dishwasher" +
                " and putting on the washing machine and tumble drier.  " + "He also needs help with breakfast, lunch and dinner and getting dressed for bed.  "
                // ....
                // ....
            });

            var p6 = svc.AddPatient(new Patient
            {
                Title = "Miss",
                Firstname = "Nancy",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR67891C",
                DOB = new DateTime(1953, 05, 28),
                Street = "29 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/6.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "Nancy@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Nancy is an elderly woman who lives on her own.  A retired teacher.  " +
                "She needs help with most things.  " + "Medication, dressing, breakfast, lunch, dinner, changing tv channels.  " +
                "Please ensure her medication is given on time.  "
                // ....
            });


            var p7 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "Brian",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR789123C",
                DOB = new DateTime(1953, 05, 28),
                Street = "30 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/7.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "Brian@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Brian loves to chat and you will often see him with his painting brushes.  Brian has some mobility issues but can dress himself.  " +
                "He needs help with his medication.  He also has some memory problems.  " +
                "He needs help with washing, putting on the dishwasher" +
                " and putting on the washing machine and tumble drier.  " + "He also needs help with breakfast, lunch and dinner and getting dressed for bed.  "
                // ....
                // ....
            });


            var p8 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "Niall",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR891012C",
                DOB = new DateTime(1950, 05, 28),
                Street = "31 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/8.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "Niall@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Niall is an elderly gentleman who lives on his own.  " +
                "He needs help with most things, " + "Medication, dressing, breakfast, lunch, dinner.  " +
                "He suffers from incontinence and needs to be changed regularly.  "
                // ....
                // ....
            });


            var p9 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "Michael",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR910234C",
                DOB = new DateTime(1953, 05, 28),
                Street = "32 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/9.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "Michael@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "Michael is an elderly gentleman who lives on his own.  " +
                "He needs help with most things, " + "Medication, dressing, breakfast, lunch, dinner."
                // ....
                // ....
            });

            var p10 = svc.AddPatient(new Patient
            {
                Title = "Mr",
                Firstname = "John",
                Surname = "Bloggs",
                NationalInsuranceNo = "NR101234C",
                DOB = new DateTime(1929, 05, 28),
                Street = "33 Warren Hill",
                Town = "Newry",
                County = "Down",
                Postcode = "BT34 2PH",
                PhotoUrl = "/images/10.jpg",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",
                Email = "Mary@mail.com",
                GP = "Dr A Blagg",
                SocialWorker = " Dr Minnie Mouse",
                CarePlan = "John loves to laugh.  John has some mobility issues but can dress himself.  " +
                "He needs help with his medication.  He also has some memory problems, his wife died recently.  " +
                "That has had an effect on him.  He needs help with washing, putting on the dishwasher" +
                " and putting on the washing machine and tumble drier.  " + "He also needs help with breakfast, lunch and dinner and getting dressed for bed.  "
                // ....
            });

            // ================== Conditions =======================
            var con1 = svc.AddCondition(new Condition
            {
                Name = "Diabetes",
                Description = "Diabetes is a condition that causes a person's blood sugar level to become too high. There are 2 main types of diabetes: type 1 diabetes - a lifelong condition where the body's immune system attacks and destroys the cells that produce insulin. type 2 diabetes - where the body does not produce enough insulin, or the body's cells do not react to insulin properly Type 2 diabetes is far more common than type 1. In the UK, over 90% of all adults with diabetes have type 2.High blood sugar that develops during pregnancy is known as gestational diabetes. It usually goes away after giving birth."
            });
            //https://www.nhs.uk/conditions/diabetes/


            var con2 = svc.AddCondition(new Condition
            {

                Name = "Arthritis",
                Description = " Arthritis is a common condition that causes pain and inflammation in a joint or joints. Arthritis affects people of all ages, including children. Osteoarthritis and rheumatoid arthritis are the 2 most common types of arthritis."
            });
            // https://www.nhs.uk/conditions/arthritis/     
            var con3 = svc.AddCondition(new Condition
            {

                Name = "Alzheimer's Disease",
                Description = "Alzheimer's disease (AD) is a neurodegenerative disease that usually starts slowly and progressively worsens,[2] and is the cause of 60–70% of cases of dementia.[2][10] The most common early symptom is difficulty in remembering recent events.[1] As the disease advances, symptoms can include problems with language, disorientation (including easily getting lost), mood swings, loss of motivation, self-neglect, and behavioral issues.[2] As a person's condition declines, they often withdraw from family and society.[11] Gradually, bodily functions are lost, ultimately leading to death. Although the speed of progression can vary, the typical life expectancy following diagnosis is three to nine years."
            });
            // https://en.wikipedia.org/wiki/Alzheimer%27s_disease

            var con4 = svc.AddCondition(new Condition
            {
                Name = "Heart Disease",
                Description = " Coronary heart disease is the term that describes what happens when your heart's blood supply is blocked or interrupted by a build-up of fatty substances in the coronary arteries.."
            });

            svc.AddPatientCondition(p1.Id, con1.Id, "Severe", DateTime.Now);
            svc.AddPatientCondition(p2.Id, con2.Id, "Moderate", DateTime.Now);
            svc.AddPatientCondition(p3.Id, con1.Id, "Severe", DateTime.Now);
            svc.AddPatientCondition(p4.Id, con2.Id, "Severe", DateTime.Now);
            svc.AddPatientCondition(p5.Id, con3.Id, "Moderate", DateTime.Now);
            svc.AddPatientCondition(p6.Id, con3.Id, "Severe", DateTime.Now);
            svc.AddPatientCondition(p7.Id, con4.Id, "Severe", DateTime.Now);
            svc.AddPatientCondition(p8.Id, con4.Id, "Moderate", DateTime.Now);
            svc.AddPatientCondition(p9.Id, con4.Id, "Severe", DateTime.Now);
            svc.AddPatientCondition(p10.Id, con3.Id, "Moderate", DateTime.Now);



            // ===========  add family ==============
            var m1 = svc.AddMember(new User
            {
                Title = "Mr",
                Firstname = "Member",
                Surname = "One",
                Email = "member1@mail.com",
                Password = "password",
                Street = "34 Big Hill",
                Town = "Rostrevor",
                County = "Down",
                Postcode = "BT34 2PH",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",

            });

            var m2 = svc.AddMember(new User
            {
                Title = "Mrs",
                Firstname = "Member",
                Surname = "Two",
                Email = "member2@mail.com",
                Password = "password",
                Street = "34 Big Hill",
                Town = "Rostrevor",
                County = "Down",
                Postcode = "BT34 2PH",
                MobileNumber = "01234567891",
                HomeNumber = "02830303030",

            });

            // ============== Schedule CareEvents APPOINTMENTS =================
            // var appointment1 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(7, 0, 0),
            //     PatientId = p1.Id,
            //     UserId = manager.Id,

            // });
            // var appointment2 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(7, 30, 0),
            //     PatientId = p2.Id,
            //     UserId = c2.Id,

            // });
            // var appointment3 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(8, 00, 0),
            //     PatientId = p3.Id,
            //     UserId = c2.Id,

            // });
            // var appointment4 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(8, 30, 0),
            //     PatientId = p4.Id,
            //     UserId = c2.Id,

            // });
            // var appointment5 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(9, 0, 0),
            //     PatientId = p5.Id,
            //     UserId = c2.Id,

            // });
            // var appointment6 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(9, 30, 0),
            //     PatientId = p6.Id,
            //     UserId = c3.Id,

            // });
            // var appointment7 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(10, 00, 0),
            //     PatientId = p7.Id,
            //     UserId = c3.Id,

            // });
            // var appointment8 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(10, 30, 0),
            //     PatientId = p8.Id,
            //     UserId = c3.Id,

            // });
            // var appointment9 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(11, 00, 0),
            //     PatientId = p9.Id,
            //     UserId = c3.Id,

            // });
            // var appointment10 = svc.AddAppointment(new Appointment
            // {

            //     Date = new DateOnly(2023, 05, 28),
            //     Time = new TimeOnly(11, 30, 0),
            //     PatientId = p10.Id,
            //     UserId = c3.Id,

            // });
            // Appointments patient 1 carer 1
            var ap1 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p1.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 7, 0, 0),
                PatientId = p1.Id,
                UserId = c1.Id,
            });
            var ap2 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p2.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 7, 30, 0),
                PatientId = p2.Id,
                UserId = c1.Id,
            });

            // // Appointments patient 2 carer 2
            var ap3 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p3.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 8, 00, 0),
                PatientId = p3.Id,
                UserId = c2.Id,
            });
            var ap4 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p4.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 8, 30, 0),
                PatientId = p2.Id,
                UserId = c2.Id,
            });
            var ap5 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p5.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 9, 0, 0),
                PatientId = p5.Id,
                UserId = c2.Id,
            });

            // // Appointments patient 3 carer 2
            var ap6 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p6.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 9, 30, 0),
                PatientId = p6.Id,
                UserId = c2.Id,
            });

            var ap7 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p7.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 10, 00, 0),
                PatientId = p7.Id,
                UserId = c2.Id,
            });

            // Appointments patient 4 carer 3
            var ap8 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p8.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 10, 30, 0),
                PatientId = p8.Id,
                UserId = c2.Id,
            });
            var ap9 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p9.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 11, 00, 0),
                PatientId = p9.Id,
                UserId = c3.Id,
            });
            var ap10 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p10.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 11, 30, 0),
                PatientId = p10.Id,
                UserId = c3.Id,
            });

            // Appointments patient 5 carer 3
            var ap11 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p1.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 12, 00, 0),
                PatientId = p1.Id,
                UserId = c3.Id,
            });
            var ap12 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p2.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 12, 30, 0),
                PatientId = p2.Id,
                UserId = c3.Id,
            });

            var ap13 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p3.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 13, 0, 0),
                PatientId = p3.Id,
                UserId = c3.Id,
            });

            // Appointments patient 6 carer 1
            var ap14 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p4.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 13, 30, 0),
                PatientId = p4.Id,
                UserId = c3.Id,
            });
            var ap15 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p5.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 14, 0, 0),
                PatientId = p5.Id,
                UserId = c3.Id,
            });
            var ap16 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p6.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 14, 45, 0),
                PatientId = p6.Id,
                UserId = c3.Id,
            });
            var ap17 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p7.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 15, 00, 0),
                PatientId = p6.Id,
                UserId = c3.Id,
            });

            // Appointments patient 7 manager
            var ap18 = svc.SchedulePatientCareEvent(new PatientCareEvent
            {
                CarePlan = p7.CarePlan,
                DateTimeOfEvent = new DateTime(2023, 05, 28, 15, 30, 0),
                PatientId = p7.Id,
                UserId = manager.Id,
            });

            // add member 1 to patient 1 family
            svc.AddPatientFamilyMember(p1.Id, m1.Id, true);
            svc.AddPatientFamilyMember(p1.Id, m2.Id, false);

        }
    }

}
