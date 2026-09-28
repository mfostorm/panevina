"""Прогон тестов через запуск программы как пользователь (stdin → stdout)."""
import subprocess, sys
from tests import TESTS
def run(script):
    out = []
    for n, inp, exp, what in TESTS:
        p = subprocess.run([sys.executable, script], input=inp + "\n", capture_output=True, text=True)
        text = (p.stdout + p.stderr).strip()
        if "Traceback" in text: got = "Аварийное завершение (" + text.strip().splitlines()[-1].split(":")[0] + ")"
        elif "Ошибка" in text: got = "Ошибка"
        else: got = text.split()[-1]
        out.append((n, inp, exp, got, "пройден" if got == exp else "НЕ пройден", what))
    return out
if __name__ == "__main__":
    for s in sys.argv[1:]:
        print("=====", s)
        for r in run(s): print(" | ".join(map(str, r)))
