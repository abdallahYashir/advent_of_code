# frozen_string_literal: true

require_relative '../lib'

def determine_game_cubes
  file_data = read_file(File.dirname(__FILE__), 'input.txt')
  games = map_data(file_data)
  games = possible_games(games)
  pp games
  games.map { |game| game[:id] }.sum
end

def map_data(data)
  data.map do |line|
    values = line.split(':')
    game = { id: extract_game_id(values[0]) }
    counts = extract_counts(values[1])
    game.merge!(counts.tally)
  end
end

def extract_game_id(value)
  value.split.last.to_i
end

def extract_counts(value)
  colours = value.gsub(';', ',').split(',').map(&:strip)
  colours.flat_map { |colour| [colour.split.last] * colour.split.first.to_i }
end

def possible_games(games)
  games.select { |game| game['red'] <= 12 && game['green'] <= 13 && game['blue'] <= 14 }
end


pp determine_game_cubes