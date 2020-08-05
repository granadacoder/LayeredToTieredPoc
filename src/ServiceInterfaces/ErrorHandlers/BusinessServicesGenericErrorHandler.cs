namespace MyCompany.MyTechnology.MyApplications.LayeredToTieredPoc.ServiceInterfaces.ErrorHandlers
{
    using System;
    using System.ServiceModel.Dispatcher;
    using System.Text;

    public class BusinessServicesGenericErrorHandler : IErrorHandler
    {
        #region IErrorHandler Members

        public bool HandleError(Exception error)
        {
            try
            {
                ////Replace with a "real" Error Exception Logging

                ////string fileName = WriteToTempFile(error.Message + System.Environment.NewLine + error.Source + System.Environment.NewLine + error.StackTrace);
                ////System.Diagnostics.Process.Start(fileName);

                StringBuilder errorMsg = new StringBuilder();

                while (null != error)
                {
                    Exception e = error;
                    errorMsg.Append(error.Message + "    \n\r\n\r    ");
                    errorMsg.Append(error.StackTrace + "    \n\r\n\r    ");
                    error = e.InnerException;
                }

                try
                {
                }
                catch (Exception ex)
                {
                    ////swallow it
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    string exceptionLogDirectory = string.Empty;

                    ////if (null != ConfigurationManager.AppSettings[ConfigKeyValues.EXCEPTION_LOG_TO_DIRECTORY])
                    ////{
                    ////    exceptionLogDirectory = ConfigurationManager.AppSettings[ConfigKeyValues.EXCEPTION_LOG_TO_DIRECTORY];
                    ////}

                    if (exceptionLogDirectory.Length > 0)
                    {
                        string fileName = exceptionLogDirectory + Guid.NewGuid().ToString("N") + ".txt";
                        this.WriteToTempFile(errorMsg.ToString(), fileName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false; ////Keep processing the Chain
        }

        public string WriteToTempFile(string toWrite, string fileName)
        {
            System.IO.StreamWriter writer = null;
            System.IO.FileStream fs = null;

            try
            {
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Append, System.IO.FileAccess.Write);
                //// Opens stream and begins writing 
                writer = new System.IO.StreamWriter(fs);
                writer.BaseStream.Seek(0, System.IO.SeekOrigin.End);
                writer.WriteLine(toWrite);
                writer.Flush();

                return fileName;
            }
            finally
            {
                if (null != writer)
                {
                    writer.Close();
                }

                if (null != fs)
                {
                    fs.Close();
                }
            }
        }

        public string WriteToTempFile(string toWrite)
        {
            // Writes text to a temporary file and returns path 
            string fileName = System.IO.Path.GetTempFileName();
            fileName = fileName.Replace(".tmp", ".txt");
            return this.WriteToTempFile(toWrite, fileName);
        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            ////Do Nothing
        }
        #endregion
    }
}