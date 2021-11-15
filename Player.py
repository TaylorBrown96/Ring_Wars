class player:
    #This is the player module for working out player movement.
    
     def __init__(self):
        self.loc = None # what room is the player in?
        self.inventory = [item.LlamaPistol(),
                          item.survivalKnife(),
                          item.briefCase()
                         ]
        #Starting inventory
