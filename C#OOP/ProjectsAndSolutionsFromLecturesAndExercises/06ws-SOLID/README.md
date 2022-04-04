## PROBLEM DESCRIPTION - SOLID (Workshop)


### Logger
Write a logging library for logging messages. The interface for the end-user should be as follows:

| Sample Source Code     | Sample Output |
| --------- | -----|
| ILayout simpleLayout = new SimpleLayout(); <br> IAppender consoleAppender = new ConsoleAppender(simpleLayout); <br> ILogger logger = new Logger(consoleAppender); <br> logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON."); <br> logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered."); | 3/26/2015 2:08:11 PM - Error - Error parsing JSON. <br> 3/26/2015 2:08:11 PM - Info - User Pesho successfully registered. <br> Press any key to continue . . . |

Logger logs data and time (string) and a message (string).

#### Library Architecture
The library should have the following components:
  +	Layouts - define the format in which messages should be appended (e.g. SimpleLayout displays logs in the format _"\<date-time\> - \<report level\> - \<message\>"_)
  +	Appenders - responsible for appending the messages somewhere (e.g. Console, File, etc.)
  +	Loggers - hold methods for various kinds of logging (warnings, errors, info, etc.)

Whenever a logger is told to log something, it calls all of its appenders and tells them to append the message. In turn, the appenders append the message (e.g. to the console or a file) according to the layout they have.

#### Requirements
Your library should correctly follow all of the SOLID principles:
  +	Single Responsibility Principle - no class or method should do more than one thing at once
  +	Open-Closed Principle - the library should be open for extension (i.e. its user should be able to create his own layouts/appenders/loggers)
  +	Liskov Substitution Principle - children classes should not break the behavior of their parent
  +	Interface Segregation Principle - the library should provide simple interfaces for the client to implement
  +	Dependency Inversion - no class/method should directly depend on concretions (only on abstractions)

Avoid code repetition. Name everything accordingly.

#### Implementations
The library should provide the following ready classes for the client:
  +	SimpleLayout - defines the format _"\<date-time\> - \<report level\> - \<message\>"_
  +	ConsoleAppender - appends a log to the console, using the provided layout
  +	FileAppender - appends a log to a file, using the provided layout
  +	LogFile - a custom file class, which logs messages in a string builder, using the method Write(). It should have a getter for its size, which is the sum of the ASCII codes of all alphabet characters it contains (e.g. a-z and A-Z)
  +	Logger - a logger class, which is used to log messages. Calls each of its appenders when something needs to be logged

| Sample Source Code     |
| --------- |
| var simpleLayout = new SimpleLayout(); <br> var consoleAppender = new ConsoleAppender(simpleLayout); <br> var file = new LogFile(); <br> var fileAppender = new FileAppender(simpleLayout, file); <br> var logger = new Logger(consoleAppender, fileAppender); <br> logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON."); <br> logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered."); |

The above code should log the messages both on the console and in log.txt in the format SimpleLayout provides.

#### Extensibility
The end-user should be able to add his own layouts/appenders/loggers and use them. For example, he should be able to create his XmlLayout and make the appenders use it, without directly editing the library source code.

| Sample Source Code     | Console Output |
| --------- | -----|
| var xmlLayout = new XmlLayout(); <br> var consoleAppender = new ConsoleAppender(xmlLayout); <br> var logger = new Logger(consoleAppender); <br> logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond"); <br> logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config"); | \<log\> <br> \<date\>3/31/2015 5:23:54 PM \</date\> <br> \<level\>Fatal\</level\> <br> \<message\>mscorlib.dll does not respond\</message\> <br> \</log\> <br> \<log\> <br> \<date\>3/31/2015 5:23:54 PM \</date\> <br> \<level\>Critical\</level\> <br> \<message\>No connection string found in App.config\</message\> <br> \</log\> <br> Press any key to continue . . . |

#### Report Threshold
Implement a report level threshold in all appenders. The appender should append only messages with report level above or equal to its report level threshold (by default all messages are appended). The report level is in the order Info > Warning > Error > Critical > Fatal.

| Sample Source Code     | Console Output |
| --------- | -----|
| var simpleLayout = new SimpleLayout(); <br> var consoleAppender = new ConsoleAppender(simpleLayout); <br> consoleAppender.ReportLevel = ReportLevel.Error; <br> var logger = new Logger(consoleAppender); <br> logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine"); <br> logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent"); <br> logger.Error("3/31/2015 5:33:07 PM", "Error parsing request"); <br> logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config"); <br> logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond"); | 3/31/2015 5:33:07 PM - Error - Error parsing request <br> 3/31/2015 5:33:07 PM - Critical - No connection string found in App.config <br> 3/31/2015 5:33:07 PM - Fatal - mscorlib.dll does not respond <br> Press any key to continue . . . |

Only messages from error and above are appended.

#### LogFile
A file should write all messages internally and it should keep information about its size.

The size of a file is calculated by summing ASCII codes of all alphabet characters (a-Z). For example, a file appender with a simple layout and a single message _"3/31/2015 5:33:07 PM - ERROR - Error parsing request"_ has size 2606 (including all characters in PM, ERROR, Error, parsing, request). In the case of XML layout, the file would have size 6632, because of the extra characters within the tags.

#### Command Interpreter
Implement a Command Interpreter, which reads all appenders that a Logger will have and input messages from the console. Every message should be evaluated by all the appenders and logged if they meet the report level. Console appenders should write directly on the console. File appenders write (save) the messages, but do not print them.

#### Input
On the first line, you will get N - the number of appenders. On the next N lines, you will get information about the appenders in one of the formats below: 
  +	_"\<appender type\> \<layout type\> \<REPORT LEVEL\>"_
  +	_"\<appender type\> \<layout type\>"_

If no report level is provided, the appender should be set to record all messages.

Next, until you get the _"END"_ command you will receive messages containing report level, time, and message separated by pipe _"|"_:
  +	_"\<REPORT LEVEL\>|\<time\>|\<message\>"_

#### Output
Console appenders should print directly at the console in the layout they are provided:
  +	Simple layout example - _"3/31/2015 5:33:07 PM - ERROR - Error parsing request"_
  +	Xml layout example (date, level, and message tags are indented by 1 tabulation):

  _\<log\>_
  
  _\<date\>3/31/2015 5:33:07 PM\</date\>_

  _\<level\>ERROR\</level\>_

  _\<message\>Error parsing request\</message\>_

  _\</log\>_

After the _"END"_ command, you should print Logger info, which includes statistics about every appender (its type, layout, report level, messages appended, and file size for file appenders):

_"Logger info_

_Appender type: \<appender type\>, Layout type: \<layout type\>, Report level: \<REPORT LEVEL\>, Messages appended: \<count\>, File size \<size\>"_

Example

| Input     | Output |
| --------- | -----|
| 2 <br> ConsoleAppender SimpleLayout CRITICAL <br> FileAppender XmlLayout <br> INFO\|3/26/2015 2:08:11 PM\|Everything seems fine <br> WARNING\|3/26/2015 2:22:13 PM\|Warning: ping is too high - disconnect imminent <br> ERROR\|3/26/2015 2:32:44 PM\|Error parsing request <br> CRITICAL\|3/26/2015 2:38:01 PM\|No connection string found in App.config <br> FATAL\|3/26/2015 2:39:19 PM\|mscorlib.dll does not respond <br> END | 3/26/2015 2:38:01 PM - CRITICAL - No connection string found in App.config <br> 3/26/2015 2:39:19 PM - FATAL - mscorlib.dll does not respond <br> Logger info <br> Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2 <br> Appender type: FileAppender, Layout type: XmlLayout, Report level: INFO, Messages appended: 5, File size: 37526 |