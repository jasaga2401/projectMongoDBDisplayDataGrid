Imports MongoDB.Bson
Imports MongoDB.Driver

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim connectionString As String = "mongodb+srv://jasaga:igywFraEIYcgiMZG@cluster0.sd0fg.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0"

        ' Create a MongoClient
        Dim client As New MongoClient(connectionString)

        ' Access the database
        Dim database As IMongoDatabase = client.GetDatabase("dbcustomer")

        ' Access the collection
        Dim collection As IMongoCollection(Of BsonDocument) = database.GetCollection(Of BsonDocument)("users")

        ' Define a filter to search for "forename" = "Kenny"
        Dim filter As FilterDefinition(Of BsonDocument) = Builders(Of BsonDocument).Filter.Eq(Of String)("forename", "Kenny")

        ' Execute the query
        Dim documents As List(Of BsonDocument) = collection.Find(filter).ToList()

        ' Convert to a DataTable for display
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("ID")
        dataTable.Columns.Add("Forename")
        dataTable.Columns.Add("Surname")

        For Each document In documents
            Dim id = document("_id").ToString()
            Dim forename = document("forename").AsString
            Dim surname = document("surname").AsString
            dataTable.Rows.Add(id, forename, surname)
        Next

        ' Bind the data to a DataGridView
        DataGridView1.DataSource = dataTable




    End Sub
End Class
