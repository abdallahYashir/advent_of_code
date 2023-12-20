# frozen_string_literal: true

require_relative '../lib'


def determine_game_cubes
  file_data = read_file(File.dirname(__FILE__), 'input.txt')
  # map the data from array of string to hash
  # first split by :
  # new Hash or Struct with Game Id
  # then last string, replace ; by ,
  # then split by ,
  # then split by space -> is there any other way to do it?
  # then use tally to count the occurence of each element??

  games = map_data(file_data)
  pp games
end

def map_data(data)
  data.map do |line|
    values = line.split(':')
    game = { id: values[0].split.last.to_i }
    colours = values[1].gsub(';', ',').split(',').map(&:strip)
    counts = colours.map do |colour|
      count, colour = colour.split
      [colour] * count.to_i
    end.flatten
    game.merge!(counts.tally)
  end
end


determine_game_cubes