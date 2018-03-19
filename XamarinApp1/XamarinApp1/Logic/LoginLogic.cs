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
            }catch(Exception ex) {   await App.Current.MainPage.DisplayAlert("Error",ex.Message,"Ok"); return null; }          
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
                await App.Current.MainPage.DisplayAlert("error", ex.Message, "ok"); return null;
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
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok"); return null;
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
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok"); return null;
            }

        }

        public async static Task<Employee> GetUserInfoResponse(int empid)
        {
            Employee employee = new Employee();
            try
            {
                var url = Employee.GenerateUserInfoURL(empid);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    employee = JsonConvert.DeserializeObject<Employee>(json);
                }
                return employee;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok"); return null;
            }

        }
    }
}
