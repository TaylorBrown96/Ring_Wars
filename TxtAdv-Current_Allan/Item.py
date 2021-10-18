

class Item:
    """
    Items are found in rooms or in player inventory.
    (Possibly we'll change that to being found in Container objects?)
     
    They may be used to solve puzzles ,give points to score, etc.
    """
    def __init__(self, name, description):
        self.name = name
        self.description = description
        
    def __str__(self):
        return self.name + ": " + self.description
'''        
class Container:
    """ This class only handles collections of Items"""
    
    def __init__(self):
        self.contents = {}
        
    def add(self, item):
        self.contents.add(item.name, item)
    def remove(self, item):
        if item in self.contents:
            self.contents.remove(item)
    def moveItemTo(self, item, destination):
        #t TODO: confirm destination is a CONTAINER!
        destination.add(item)
        self.remove(item)
'''
#test code
def main():
    key = Item("key", "It's a bit rusty.")
    
    sword = Item("sword", "It's very sharp.")
    
    stuff = [key,sword]
    for item in stuff:
        print(item)
    
    
    
if __name__ == "__main__":
    main()