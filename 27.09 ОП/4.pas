Uses crt;
Const n = 5; m = 3; 
Var a :array [1..m,1..n]of real;
    b :array [1..n,1..m]of real;
    i,j :integer;
Begin
  Randomize;
  for i:=1 to m do
  for j:=1 to n do
  begin
    a[i,j]:=random(10);
    GoToXY(5*j+2,i+3); writeln (a[i,j]);
    
  end;
    
  for i:=1 to m do
  for j:=1 to n do
  b[j,i] := a[i,j];
      
  for i:=1 to m do
    for j:=1 to n do
      begin
        GoToXY(5*i+2,j+8);
        writeln (b[j,i]);
      end;
  
end.