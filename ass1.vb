Imports System
Imports System.Collections.Generic

Public Class Student
    Public Property RollNumber As Integer
    Public Property Name As String
    Public Property Age As Integer
    Public Property Course As String
    Public Property Batch As String
    Public Sub New(rollNumber As Integer, name As String, age As Integer, course As String, batch As String)
        Me.RollNumber = rollNumber
        Me.Name = name
        Me.Age = age
        Me.Course = course
        Me.Batch = batch
    End Sub
    Public Function DisplayDetails() As String
        Return $"Roll Number: {RollNumber}, Name: {Name}, Age: {Age}, Course: {Course}, Batch: {Batch}"
    End Function
End Class

Module MainModule
    Sub Main()
        Dim students As New List(Of Student)()

        While True
            DisplayMenu()

            Dim choice As Integer = GetChoice()

            Select Case choice
                Case 1
                    CreateStudent(students)
                Case 2
                    DisplayStudentDetails(students)
                Case 3
                    UpdateStudentDetails(students)
                Case 4
                    DeleteStudentDetails(students)
                Case 5
                    ExitProgram()
                Case Else
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.")
            End Select

            Console.WriteLine()
        End While
    End Sub
    Private Sub DisplayMenu()
        Console.WriteLine("Menu:")
        Console.WriteLine("1. Create New Student")
        Console.WriteLine("2. Display Student Details")
        Console.WriteLine("3. Update Student Details")
        Console.WriteLine("4. Delete Student Details")
        Console.WriteLine("5. Exit")
        Console.Write("Enter your choice: ")
    End Sub
    Private Function GetChoice() As Integer
        Dim choice As Integer
        Integer.TryParse(Console.ReadLine(), choice)
        Return choice
    End Function
    Private Sub CreateStudent(ByVal students As List(Of Student))
        Console.WriteLine("Creating a new student...")
        Console.Write("Enter roll number: ")
        Dim rollNumber As Integer
        Integer.TryParse(Console.ReadLine(), rollNumber)
        Console.Write("Enter student name: ")
        Dim name As String = Console.ReadLine()
        Console.Write("Enter student age: ")
        Dim age As Integer
        If Integer.TryParse(Console.ReadLine(), age) Then
            Console.Write("Enter student course: ")
            Dim course As String = Console.ReadLine()
            Console.Write("Enter student batch: ")
            Dim batch As String = Console.ReadLine()
            students.Add(New Student(rollNumber, name, age, course, batch))
            Console.WriteLine("Student created successfully.")
        Else
            Console.WriteLine("Invalid age input.")
        End If
    End Sub
    Private Sub DisplayStudentDetails(ByVal students As List(Of Student))
        If students.Count > 0 Then
            Console.WriteLine("Student Details:")
            For Each student As Student In students
                Console.WriteLine(student.DisplayDetails())
            Next
        Else
            Console.WriteLine("No student records found.")
        End If
    End Sub
    Private Sub UpdateStudentDetails(ByVal students As List(Of Student))
        If students.Count > 0 Then
            Console.WriteLine("Updating student details...")
            Console.Write("Enter roll number of the student to update: ")
            Dim rollNumber As Integer
            If Integer.TryParse(Console.ReadLine(), rollNumber) Then
                Dim found As Boolean = False
                For Each student As Student In students
                    If student.RollNumber = rollNumber Then
                        Console.Write("Enter student name: ")
                        student.Name = Console.ReadLine()
                        Console.Write("Enter student age: ")
                        Dim age As Integer
                        If Integer.TryParse(Console.ReadLine(), age) Then
                            student.Age = age
                            Console.Write("Enter student course: ")
                            student.Course = Console.ReadLine()
                            Console.Write("Enter student batch: ")
                            student.Batch = Console.ReadLine()
                            Console.WriteLine("Student details updated successfully.")
                        Else
                            Console.WriteLine("Invalid age input.")
                        End If
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    Console.WriteLine("Student not found.")
                End If
            Else
                Console.WriteLine("Invalid roll number input.")
            End If
        Else
            Console.WriteLine("No student records found.")
        End If
    End Sub
    Private Sub DeleteStudentDetails(ByVal students As List(Of Student))
        If students.Count > 0 Then
            Console.WriteLine("Deleting student details...")
            Console.Write("Enter roll number of the student to delete: ")
            Dim rollNumber As Integer
            If Integer.TryParse(Console.ReadLine(), rollNumber) Then
                Dim found As Boolean = False
                For i As Integer = 0 To students.Count - 1
                    If students(i).RollNumber = rollNumber Then
                        students.RemoveAt(i)
                        Console.WriteLine("Student details deleted successfully.")
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    Console.WriteLine("Student not found.")
                End If
            Else
                Console.WriteLine("Invalid roll number input.")
            End If
        Else
            Console.WriteLine("No student records found.")
        End If
    End Sub
    Private Sub ExitProgram()
        Console.WriteLine("Exiting the program...")
        Environment.Exit(0)
    End Sub
End Module
