# frozen_string_literal: true

def read_file(directory, filename)
  file_path = File.join(directory, filename)
  File.readlines(file_path).map(&:chomp)
end
