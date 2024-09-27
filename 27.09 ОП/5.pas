Uses crt;
Const n = 2; m = 3; k = 4;
Var a :array [1..n,1..m]of real;
    b :array [1..m,1..k]of real;
    c :array [1..n,1..k]of real;
    i,j,p :integer;
    S :real;
Begin
  Randomize;
  S:=0;
  for i:=1 to n do
  for j:=1 to m do
  begin
    a[i,j]:=random(10);    
    GoToXY(5*j+2,i+3); writeln (a[i,j]);    
  end;
  for i:=1 to m do
  for j:=1 to k do
  begin
    b[i,j]:=random(10);    
    GoToXY(5*j+2,i+9); writeln (b[i,j]);    
  end;
    
  for i:=1 to n do
  for j:=1 to k do
  begin
    for p:=1 to m do
    c[i,j]:=a[i,p]*b[p,j];
  end;
      
  for i:=1 to n do
  for j:=1 to k do
  begin
    GoToXY(5*j+2,i+16); writeln (c[i,j]);
  end;
  
end.