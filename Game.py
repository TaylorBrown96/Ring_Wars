import M3LAB1_BrownTaylor as GE


"""
    -User input is asked for and recived and then split so you can take the
     first word and asign it to a nested declaration

    -If the user typed "go" followed by a direction:
        -The second word in the user input is the desired direction of travel 
        and will either display "There isn't an exit in that direction." or 
        it will display the room name

    -The user will then be prompted again in which direction they wish to travel

    -If the user types "help" display what exit and look does

    -If the user types "look" display the room description and the exits

    -If the user types "exit" the program should terminate with a goodbye message

    -If the user submits a typo display "I'm sorry, but I dont reconize that command."
"""

def main():
    # This code takes user input and displays the new information accordingly
    GE.loc = GE.livingRoom
    print("Starting room:")
    GE.loc.room_print()
    keep_going = 0
    while keep_going == 0: 
        print('Enter your direction of travel.')
        usr_inp = input("TYPE: go North, South, East, West (type 'help'): ")
        usr_inp.lower()
        split_inp = usr_inp.split()

        # Checks to Verb in the input
        if split_inp[0] == "go":
            if split_inp[1] == "south":# Trys to go: South
                try:
                    GE.loc = GE.roomDict[GE.loc.exits[split_inp[1]]]
                    print ("\nHeading South...")
                    GE.loc.room_print()
                except:
                    print("\nThere are no exits in this direction\n")
                    pass
            elif split_inp[1] == "north":# Trys to go: North
                try:
                    GE.loc = GE.roomDict[GE.loc.exits[split_inp[1]]]
                    print ("\nHeading North...")
                    GE.loc.room_print()
                except:
                    print("\nThere are no exits in this direction\n")
                    pass
            elif split_inp[1] == "east":# Trys to go: East
                try:
                    GE.loc = GE.roomDict[GE.loc.exits[split_inp[1]]]
                    print ("\nHeading East...")
                    GE.loc.room_print()
                except:
                    print("\nThere are no exits in this direction\n")
                    pass
            elif split_inp[1] == "west":# Trys to go: West
                try:
                    GE.loc = GE.roomDict[GE.loc.exits[split_inp[1]]]
                    print ("\nHeading West...")
                    GE.loc.room_print()
                except:
                    print("\nThere are no exits in this direction\n")
                    pass
            else:
                print("\ninvalid command\n")
        
        # Displays the room description and exits
        elif split_inp[0] == "look":
            GE.loc.look()

        # Displays the other user commands hidden from view initally
        elif split_inp[0] == "help":
            print("\n-'exit' to quit the game at any time")
            print("-'look' to get a description of the room and exits\n")

        elif split_inp[0] == "exit":
            print("Exiting the game!", "\n")
            keep_going += 1

        else:
            print("\n", "I'm sorry, but I dont reconize that command.", "\n", sep='')
            
            
if __name__ == "__main__":
    main()