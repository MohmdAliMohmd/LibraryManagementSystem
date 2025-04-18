SELECT name, physical_name AS file_path
FROM sys.master_files
WHERE database_id = DB_ID('YourDatabaseName');