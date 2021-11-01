#
#
#
#


class Room:

    def __init__(self, room_name, room_desc, exits, containers):
        self.room_name = room_name
        self.room_desc = room_desc
        self.exits = exits
        self.containers = containers

    def __str__(self):
        return self.room_name + " : " + self.room_desc + " : " + self.exits + " : " 

class Container:

    def __init__(self, name, contents):
        self.name = name
        self.contents = contents

def main():
    livingRoom_container = Container("Couch", "There are shinny pennies inbetween the cushions")
    livingRoom = Room("Living Room", "There is a sofa and a TV playing a soap opera", {"North": "bedroom"}, livingRoom_container)

    rooms = [livingRoom]

    print(Room.rooms)

if __name__ == "__main__":
    main()