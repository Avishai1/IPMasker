// See https://aka.ms/new-console-template for more information
try
{

    string fileNameInput = Environment.GetCommandLineArgs()[1];
    ValidateFile(fileNameInput);

    string input = File.ReadAllText(fileNameInput);
    string output = new IPMasker.IPMasker().ReplaceIPAddresses(input);
    File.WriteAllText("output.log", output);
    Console.WriteLine("Output File is ready at root path");
}
catch (Exception ex)
{
    Console.WriteLine("Exception: " + ex.Message);
}
/// <summary>
/// Validates that the file exists, with ".log" suffix and less than 5MB
/// </summary>
void ValidateFile(string fileNameInput)
{
    if (!File.Exists(fileNameInput))
        throw new FileNotFoundException();
    FileInfo fileInfo = new FileInfo(fileNameInput);
    string fileSuffix = fileInfo.Name.Substring(Math.Max(0, fileInfo.Name.Length - 4));
    if (fileSuffix != ".log")
        throw new Exception("The file format is not applicable. Please enter a '*.log' file.");
    if (fileInfo.Length > 5000000)
        throw new Exception("File is larger than 5MB. Please enter a smaller file");
}