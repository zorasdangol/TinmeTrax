using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamarinApp1.Models;
using XamarinApp1.UserInterfaces;

namespace XamarinApp1.Logic
{
    public class LoginLogic
    {
        public async static Task<string> GetLoginResponse(int empid,string pwd)
        {
            try
            {
                string login = "";
                var url = User.GenerateLoginURL(empid, pwd);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    login = await response.Content.ReadAsStringAsync();
                }
                return login;
            }catch(Exception ex) {
                await App.Current.MainPage.DisplayAlert("Error","Internet is not available or Server not found","Ok");
                //await App.Current.MainPage.Navigation.PushAsync(new NoResponsePage());
                return null; }          
        }

        public async static Task<List<Attendance>> GetAttendanceResponse(int empid,DateTime SDate, DateTime EDate )
        {
            try
            {
                var url = Attendance.GenerateAttendanceURL(empid, SDate, EDate);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    
                    var AttendanceList = JsonConvert.DeserializeObject<List<Attendance>>(json);
                    return AttendanceList;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Attendance not loaded", "Internet is not available or Server not found","OK");
                return null;
            }

        }


        public async static Task<List<LeaveSummary>> GetLeaveSummaryResponse(int empid)
        {
            try
            {
                List<LeaveSummary> LeaveSummaryList = new List<LeaveSummary>();                
                var url = LeaveSummary.GenerateLeaveSummaryURL(empid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    LeaveSummaryList= JsonConvert.DeserializeObject<List<LeaveSummary>>(json) ;
                }
                return LeaveSummaryList;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Leave Summary Info not loaded", "Internet is not available or Server not found", "OK");
                return null;
            }

        }


        public async static Task<List<Leave>> GetLeaveResponse(int empid)
        {
            try
            {
                List<Leave> LeaveList = new List<Leave>();
                var url = Leave.GenerateLeaveURL(empid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    LeaveList = JsonConvert.DeserializeObject<List<Leave>>(json);
                }
                return LeaveList;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Leave Info not Loaded", "Internet is not available or Server not found", "OK");               
                return null;
            }

        }

        public async static Task<Employee> GetUserInfoResponse(int empid)
        {
            Employee employee = new Employee();
            try
            {
                var url = Employee.GenerateUserInfoURL(empid);
                if(Helpers.Data.Employee.EmpID != Helpers.Data.User.EmpId)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetAsync(url);
                        var json = await response.Content.ReadAsStringAsync();
                        employee = JsonConvert.DeserializeObject<Employee>(json);
                        //Helpers.Data.Employee = employee;
                    }
                    return employee;
                }
                return Helpers.Data.Employee;               
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Employee Info not loaded", "Internet is not available or Server not found", "OK");               
                return null;
            }                                                        
        }

        public async static Task<string> GetAuthApiResponse(string ipAddress, string pwd)
        {
            try
            {
                string apiset = "";
                var url = API.GenerateAuthApiURL(ipAddress, pwd);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    apiset = await response.Content.ReadAsStringAsync();
                }
                return apiset;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Incorrect Url address or no Internet Connection", "Ok");
                return null;
            }
        }

    }
}
