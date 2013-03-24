using System;
using System.Collections.Generic;
using System.Linq;

public class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddDocument(string[] attributes, IDocument doc)
    {
        foreach (var attrib in attributes)
        {
            string[] currentAttribute = attrib.Split('=');
            string key = currentAttribute[0];
            string value = currentAttribute[1];
            doc.LoadProperty(key, value);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: " + doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        TextDocument doc = new TextDocument();

        AddDocument(attributes, doc);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        PDFDocument doc = new PDFDocument();

        AddDocument(attributes, doc);
    }

    private static void AddWordDocument(string[] attributes)
    {
        WordDocument doc = new WordDocument();

        AddDocument(attributes, doc);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        ExcelDocument doc = new ExcelDocument();

        AddDocument(attributes, doc);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AudioDocument doc = new AudioDocument();

        AddDocument(attributes, doc);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        VideoDocument doc = new VideoDocument();

        AddDocument(attributes, doc);
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (var doc in documents)
            {
                Console.WriteLine(doc);
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        int counter = 0;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                counter++;
                var curr = doc as IEncryptable;
                if (curr != null)
                {
                    curr.Encrypt();
                    Console.WriteLine("Document encrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: " + name);
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
        //var docs =
        //          from doc in documents
        //          where doc.Name == name
        //          select doc as IEncryptable;
        //foreach (var d in docs)
        //{
        //    d.Encrypt();
        //}
    }

    private static void DecryptDocument(string name)
    {
        int counter = 0;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                counter++;
                var curr = doc as IEncryptable;
                if (curr != null)
                {
                    curr.Decrypt();
                    Console.WriteLine("Document decrypted: " + name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: " + name);
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }

    private static void EncryptAllDocuments()
    {
        int counter = 0;
        var docs =
                  from doc in documents
                  where doc as IEncryptable != null
                  select doc as IEncryptable;
        foreach (var d in docs)
        {
            d.Encrypt();
            counter++;
        }

        if (counter != 0)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        int counter = 0;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                counter++;
                var curr = doc as IEditable;
                if (curr != null)
                {
                    curr.ChangeContent(content);
                    Console.WriteLine("Document content changed: " + name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: " + name);
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("Document not found: " + name);
        }
    }
}