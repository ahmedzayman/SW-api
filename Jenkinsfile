pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat 'dotnet build ./RESTApi/RESTApi.sln'
                bat 'dotnet build ./GrpcService/GrpcService.sln'
            }
        }
        stage('Test') {
            steps {
                bat 'dotnet test ./RESTApi/RESTApi.sln'
                bat 'dotnet test ./GrpcService/GrpcService.sln'
            }
        }
        stage('Docker Build') {
            steps {
                bat 'docker-compose build'
            }
        }
        stage('Deploy') {
            steps {
                bat 'docker-compose up -d'
            }
        }
    }
}