pipeline {
    agent any
    
    stages {
        stage('Code Checkout'){
            steps {
                git branch: 'main', url: 'https://github.com/gopal3670/app_gopalkumar.git'
            }
        }
        stage('Nuget Restore'){
            steps {
                bat 'dotnet restore'
            }
        }
        stage('Clean'){
            steps {
                bat 'dotnet clean'
            }
        }
        stage('Build'){
            steps {
                bat 'dotnet build'
            }
        }
        stage('Test'){
            steps {
                bat 'dotnet test --logger:trx;LogFileName=appgopalkumartest.xml'
            }
        }
    }
}