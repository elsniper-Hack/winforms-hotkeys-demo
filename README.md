# winforms-hotkeys-demo
# Windows Hotkeys con WinAPI (C#)

Este proyecto demuestra cómo implementar hotkeys globales en Windows utilizando la API nativa (`RegisterHotKey`) combinada con una aplicación ligera en Windows Forms.

## Características

  Detección de hotkeys globales (A, F, S, J)
  Ejecución en segundo plano (sin ventana visible)
  Renderizado de GIF usando recursos embebidos
  Posición aleatoria en pantalla
  Generación de ejecutable portable (single file)

## Tecnologías utilizadas

  C#
  .NET 8
  Windows Forms
  WinAPI (`user32.dll`)

## Objetivo

Este proyecto fue desarrollado como práctica para comprender:

  El loop de mensajes de Windows (`WndProc`)
  Interacción con APIs nativas
  Aplicaciones en segundo plano
  Uso de recursos embebidos en .NET
  Creación de binarios portables

## Compilación

```bash
dotnet publish -c Release
