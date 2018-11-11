using System;
using System.Text;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
       
      static void err(string ex) 
      {
          try
          {
              FileStream file_err = new FileStream(Directory.GetCurrentDirectory() + "\\dri_err.dr", FileMode.OpenOrCreate, FileAccess.Write);
              StreamWriter sr_err = new StreamWriter(file_err);
              sr_err.WriteLine(ex);
              sr_err.Close();
          }
          catch (Exception)
          {
              
              
          }
          
      }
        static void search()
        {
               try
            {
                int p = -1;
                DriveInfo[] drives = DriveInfo.GetDrives();
                string[] s = new string[drives.Length];
                for (int i = 0; i < drives.Length; i++)
                {
                    
                    DriveInfo drive = drives[i];
                    if (drive.DriveType == DriveType.Fixed && drive.Name!="C:\\")
                    {
                        p++;
                        s[p] = drive.Name; 
                        
                    }
                }
               flie(s,0);
               search(s,0);
            }
              catch (Exception ex)
            {

                err("void search() :" + ex.Message);
            }

        }//for drive
    
        static void search(string []d,int n)
        {
            int m=0 ;
            try
            {
                string[] s = new string[d.Length];
                for ( m = n; m < d.Length; m++)
                {
                            
                            s = Directory.GetDirectories(d[m]);
                            flie(s, 0);
                            search(s, 0); 
                }
               
                
            }
            catch (Exception ex)
            {
                 if (ex.Message=="Access to the path '"+ d[m] +"' is denied.")
                {
                    search(d, ++m);
                }
                 err("void search(string []d,int n) :" + ex.Message);
                
            }   
        }//for directory
        static void flie(string[] d , int n) 
        {
            int m=0;
            try
            {
                if (n<=d.Length)
                {
                    string[] s = new string[d.Length];
                    for (m = n; m < d.Length; m++)
                    {

                        {
                            
                            s = Directory.GetFiles(d[m]);

                           
                        }
                        copy(s);

                    }
                }
                

            }
            catch (Exception ex)
            {
               if (ex.Message=="Access to the path '"+ d[m] +"' is denied.")
                {
                    flie(d, ++m);
                }
               err("void flie(string[] d , int n)   :" + ex.Message);

            }   
        }
        static void copy(string[]s) //for copy file
        {
            try
            {

                FileStream file = new FileStream(Directory.GetCurrentDirectory() + "\\dri.dr", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sr = new StreamWriter(file);
               // System.IO.File.Copy("F:\\image\\*.jpg", "c:\\a\\.2j", true);
                
                for (int n = 0; n < s.Length; n++)
                        if (s!=null)
                        {
                            Console.WriteLine(s[n]);

                            sr.WriteLine(s[n]);

                        }
                
                sr.Close();
            }
            catch (Exception ex)
            {

                err("void copy(string[]s) :" + ex.Message);
            }
            
        }
        static void Main(string[] args)
        {
            try
            {
 
                    search();
            }
            catch (Exception ex)
            {
                err("void Main(string[] args) :" + ex);  
            }
            Console.Read();
        }
        
    }
}
