#Container class
#moving object from container to container

class Container:
    """ This class only handles collections of Items"""
    
    def __init__(self):
        self.contents = {}
        
    def add(self, item):
        self.contents.add(item.name, item)
    def remove(self, item):
        if self.contains(item):
            self.contents.remove(item)
    def moveItemTo(self, item, destination):
        #t TODO: confirm destination is a CONTAINER!
        destination.add(item)
        self.remove(item)
        
    def listContents(self):
        for key in self.contents:
            print(key)
        
    """Function busted. An unholy list of items, keys, list and, more"""
    def contains(self, itemName):
        """quick way to check if item is present. """
        # keys() gives us a list of names of items present
        itemNameList = list(self.contentskeys())
        if itemName in itemNameList:
            return True
        return False