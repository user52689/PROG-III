<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccesoDenegado.aspx.cs" Inherits="Vistas.Inicio.AccesoDenegado" %>
<%@ Import Namespace="Entidades" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Error 403</title>
   <link href="../Estilos/Estilos.css" rel="stylesheet" />
<style>
        .container {
            text-align: center;
            color: #333;
            background-color: white;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.1);
            max-width: 600px;
            margin: 0 auto;
        }

        h1 {
            font-size: 48px;
            color: #d9534f;
            margin-bottom: 20px;
            animation: shake 0.5s ease-in-out;
        }

        @keyframes shake {
            0%, 100% { transform: translateX(0); }
            25% { transform: translateX(-5px); }
            50% { transform: translateX(5px); }
            75% { transform: translateX(-5px); }
        }

        .error-message {
            font-size: 18px;
            color: #555;
            margin-bottom: 20px;
        }

        .error-icon {
            font-size: 100px;
            color: #d9534f;
            animation: pulse 1.5s infinite;
        }

        @keyframes pulse {
            0% { transform: scale(1); }
            50% { transform: scale(1.1); }
            100% { transform: scale(1); }
        }

        .return-link {
            display: inline-block;
            padding: 12px 24px;
            background-color: #007BFF;
            color: white;
            text-decoration: none;
            border-radius: 5px;
            font-weight: bold;
            transition: background-color 0.3s ease;
        }

        .return-link:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="error-icon">🚫</div>
            <h1>Error 403</h1>
            <p class="error-message">
             <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message"></asp:Label>
            </p>
            <a href="InicioSesion.aspx" class="return-link">Volver al Inicio</a>
        </div>
    </form>
</body>
</html>