using ChangeGuidsTextTool;
using MiscUtil.IO;
using System.Text.RegularExpressions;

//bin/Debug/Net6.0
//Copy whole book or just tasks you need into book.txt 
//Copy more than you need newly generated guids in guids.txt
//Start
//newBook <- whole book/tasks wtih new guids and sportsbook name
//newGuidsForScript <- guids in format easy to copy into script
//guidsForScript <- in case you just need guids for script from tasks that don't need change

Services service = new Services();
service.makeNewBookAndScript();
service.extractGuids();






