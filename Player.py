import item

class player:
    #This is the player module for working out player movement.
    
     def __init__(self):
        self.loc = None # what room is the player in?
        self.inventory = [item.LlamaPistol(),
                          item.survivalKnife(),
                          item.briefCase()
                         ]
        #Starting inventory
        self.victory = False
        self.hp = 100
        
    def alive(self):
        return self.hp > 0
    
    def openInventory(self):
        #Opening the Inventory
        for item in self.invetory:
            print("*" + str(item))
        print("*Brief Case: {}".formate(self.BriefCase())
        
