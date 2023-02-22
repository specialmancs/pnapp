# import ctypes  # An included library with Python install.
# def Mbox(title, text, style):
#     return ctypes.windll.user32.MessageBoxW(0, text, title, style)
# Mbox('Your title', 'Your text', 0)

# import easygui
# easygui.msgbox("This is a message!", title="simple gui")


import pymsgbox
pymsgbox.alert('This is an alert!', 'Title')
response = pymsgbox.prompt('What is your name?')