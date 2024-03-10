import os
import shutil
from pathlib import Path


def main():
    path = "C:\\projetos\\net\\AutonomoApp\\src"

    if os.path.exists(path + "out"):
        shutil.rmtree(path + "out")

    del_tree(path, "obj", False)
    del_tree(path, "bin", True)

    create_bin_folders(path, "*.Console")
    create_bin_folders(path, "*.Business")
    create_bin_folders(path, "*.Data")
    create_bin_folders(path, "*.Api")
    input()


def create_bin_folders(path, search_pattern):
    directories = [d for d in Path(path).rglob(search_pattern) if d.is_dir()]

    for directory in directories:
        bin_path = Path(directory, "bin")

        if not os.path.exists(bin_path):
            os.mkdir(bin_path)

    print(f"{len(directories)} Pastas {search_pattern}\\bin Criadas.")


def del_tree(path, search_pattern, create_after_remove):
    directories = [d for d in Path(path).rglob(search_pattern) if d.is_dir()]

    for directory in directories:
        if os.path.exists(directory):
            shutil.rmtree(directory, ignore_errors=True)

        if create_after_remove:
            os.mkdir(directory)


if __name__ == "__main__":
    main()
