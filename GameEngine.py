# CSC 221
# Text Adventure - M3LAB1_BrownTaylor.py
# Taylor J. Brown
# 10/5/21

class Room:
    """
    The Room class holds names, descriptions, and exits.
    ****************************************************
    It also converts the variables to strings in methods, so it is human readable.
    """

    def __init__(self,container, name, description, exits):
        self.container = container
        self.name = name
        self.description = description
        self.exits = exits

    def room_print(self):
        """ print full room description. """
        print("Room: ",self.name, '\n')
    
    def look(self):
        """ prints the room description. """
        # Appends all the exits
        text = '\n'
        text += "_____Exits_____ " + "\n"
        exitList = self.exits.keys() # this gives us a list of all directions present in exits
        for direction in exitList:
            text += direction                     # North, South, etc. 
            text += ": " + self.exits[direction] + "\n"
            
        for key in self.container:
            text += self.container[key[0]] + " "

        print('\n',"Description: ", self.description, text, "\n", sep='')
      


def main():
    """
        -This is used for testing the game engine
    """
    pass






"""
-Room containers are declared above the rooms and added to the room formats

-Rooms are declared with their descriptions and exits using the format below

-Rooms are appended to a dictionary and the starting room is set

Formated room declarations:
room_variable_name = Room(room_containers, "room_name", "room_description",
                          {"exit_direction" : "where_it_goes",
                           "exit_direction" : "where_it_goes"
                          } )
"""

# BedRoom
bedroom_C = {"1":"Thing 1", "2":"Thing 2"}
bedroom = Room(bedroom_C, "Bedroom", "Your wife is asleep in bed still.",
               # The exits for this room
                {"west": "Living Room",
                 "south": "Bathroom"
                } )

# LivingRoom
livingRoom_C = {"1":"Thing 1", "2":"Thing 2"}
livingRoom = Room(livingRoom_C, "Living Room", "The TV is playing a show and the couch looks comfortable.",
               # The exits for this room
                  {  "north" : "Kitchen",
                     "east" : "Bedroom",
                     "west" : "Garage"
                  } )

# Bathroom
bathroom_C = {"1":"Thing 1", "2":"Thing 2"}
bathRoom = Room(bathroom_C, "Bathroom", "There is a set of clean clothes on the counter for you.",
               # The exits for this room
                {"north": "Bedroom"
                 } )

# Garage
garage_C = {"1":"Thing 1", "2":"Thing 2"}
garage = Room(garage_C, "Garage", "Your car is parked the keys are on the nightstand in the bedroom.",
               # The exits for this room
              { "east" : "Living Room"
              } )

# Kitchen
kitchen_C = {"1":"Thing 1", "2":"Thing 2"}
kitchen = Room(kitchen_C, "Kitchen", "The sink has a constant drip.",
               # The exits for this room
               { "south" : "Living Room"
               } )

# Places rooms in a dictionary.
roomDict = { bedroom.name:   bedroom, 
            livingRoom.name: livingRoom,
            bathRoom.name:   bathRoom,
            garage.name:     garage,
            kitchen.name:    kitchen}


if __name__ == "__main__":
    main()