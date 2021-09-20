import os
import win32com.client
try: # for python 2.x
    from Tkinter import *
    from tkMessageBox import *
    from tkFileDialog import *
except: # for python 3.x
    from tkinter import *
    from tkinter.messagebox import *
    from tkinter.filedialog import *

APP_TITLE = "Virtual UI Notepad"

class Notepad:

    #variables
    tkRoot = Tk()
    TextArea = Text(tkRoot)
    MenuBar = Menu(tkRoot)
    FileMenu = Menu(MenuBar)
    EditMenu = Menu(MenuBar)
    HelpMenu = Menu(MenuBar)
    ScrollBar = Scrollbar(TextArea)

    CurrFileName = None

    def __init__(self, width=300, height=300):

        # Default window title is "Untitled"!
        self.tkRoot.title("Untitled - " + APP_TITLE)

        # set window size
        self.tkRoot.geometry('%dx%d' % (width, height))

        # make the textarea auto resizable
        self.tkRoot.grid_rowconfigure(0,weight=1)
        self.tkRoot.grid_columnconfigure(0,weight=1)

        # Widgets
        self.TextArea.grid(sticky=N+E+S+W)

        # file menu
        self.FileMenu.add_command(label="New",command=self.doNewFile)
        self.FileMenu.add_command(label="Open",command=self.doOpenFile)
        self.FileMenu.add_command(label="Save",command=self.doSaveFile)
        self.FileMenu.add_separator()
        self.FileMenu.add_command(label="Exit",command=self.quit)
        self.MenuBar.add_cascade(label="File",menu=self.FileMenu)

        # edit menu
        self.EditMenu.add_command(label="Cut",command=self.doCut)
        self.EditMenu.add_command(label="Copy",command=self.doCopy)
        self.EditMenu.add_command(label="Paste",command=self.doPaste)
        self.MenuBar.add_cascade(label="Edit",menu=self.EditMenu)

        # help menu
        self.HelpMenu.add_command(label="About",command=self.aboutDialog)
        self.MenuBar.add_cascade(label="Help",menu=self.HelpMenu)

        self.tkRoot.config(menu=self.MenuBar)

        self.ScrollBar.pack(side=RIGHT,fill=Y)
        self.ScrollBar.config(command=self.TextArea.yview)
        self.TextArea.config(yscrollcommand=self.ScrollBar.set)

        self.VirtualUI = win32com.client.Dispatch("Thinfinity.VirtualUI")

    def quit(self):
        self.tkRoot.destroy()

    def aboutDialog(self):
        showinfo("Notepad","Sample application for Virtual UI\n"+str(self.VirtualUI.browserInfo.customData)+"\n------")

    def doOpenFile(self):

        self.CurrFileName = askopenfilename(defaultextension=".txt",filetypes=[("All Files","*.*"),("Text Documents","*.txt")])

        if self.CurrFileName == "": # no file has been selected
            self.CurrFileName = None
        else:
            self.TextArea.delete(1.0,END)
            try:
                file = open(self.CurrFileName,"r")
                self.TextArea.insert(1.0,file.read())
                file.close()

                # adjust window title
                self.tkRoot.title(os.path.basename(self.CurrFileName) + " - " + APP_TITLE)
            except:
                showerror('Unexpected error!')
                self.CurrFileName = None


    def doNewFile(self):
        self.tkRoot.title("Untitled - " + APP_TITLE)
        self.CurrFileName = None
        self.TextArea.delete(1.0,END)

    def doSaveFile(self):

        if self.CurrFileName == None:
            # No previous filename- act as "save as"
            self.CurrFileName = asksaveasfilename(initialfile='Untitled.txt',defaultextension=".txt",filetypes=[("All Files","*.*"),("Text Documents","*.txt")])

            if self.CurrFileName == "":
                self.CurrFileName = None
            else:
                # try to save the file
                file = open(self.CurrFileName,"w")
                file.write(self.TextArea.get(1.0,END))
                file.close()
                # change the window title
                self.tkRoot.title(os.path.basename(self.CurrFileName) + " - " + APP_TITLE)


        else:
            file = open(self.CurrFileName,"w")
            file.write(self.TextArea.get(1.0,END))
            file.close()

    def doCut(self):
        self.TextArea.event_generate("<<Cut>>")

    def doCopy(self):
        self.TextArea.event_generate("<<Copy>>")

    def doPaste(self):
        self.TextArea.event_generate("<<Paste>>")

    def run(self):
        self.VirtualUI.Start (60)
        self.tkRoot.mainloop()

def main():
    #run main application
    notepad = Notepad(600,400)
    notepad.run()

if __name__ == '__main__':
    main()
