using Microsoft.ProgramSynthesis;
using Microsoft.ProgramSynthesis.AST;
using Microsoft.ProgramSynthesis.Compiler;

// Parse the DSL grammar above, saved in a .grammar file
var grammar = DSLCompiler.LoadGrammarFromFile("SubstringExtraction.grammar").Value; // HL
// Parse a program in this grammar. PROSE supports two serialization formats:
// "human-readable" expression format, used in this tutorial, and machine-readable XML.
var ast = grammar.ParseAST("Substring(inp, PosPair(AbsolutePosition(inp, 0), AbsolutePosition(inp, 5)))", // HL
                           ASTSerializationFormat.HumanReadable); // HL
// Create an input state to the program. It contains one binding: a variable 'inp' (DSL input)
// is bound to the string "PROSE Rocks".
var input = State.Create(grammar.InputSymbol, "PROSE Rocks"); // HL
// Execute the program on the input state.
var output = (string) ast.Invoke(input); // HL
Assert(output == "PROSE");